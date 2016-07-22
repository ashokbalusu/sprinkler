﻿using System;
using System.Collections.Generic;
using System.Net;
using Furore.Fhir.Sprinkler.FhirUtilities.ResourceManagement;
using Furore.Fhir.Sprinkler.XunitRunner.FhirExtensions;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Xunit;
using Assert = Furore.Fhir.Sprinkler.FhirUtilities.Assert;
using System.Linq;

namespace Furore.Fhir.Sprinkler.Xunit.TestSet
{
    [FixtureConfiguration(FixtureType.File)]
    [TestCaseOrderer("Furore.Fhir.Sprinkler.XunitRunner.FhirExtensions.PriorityOrderer", "Furore.Fhir.Sprinkler.XunitRunner")]
    public class CreateUpdateDeleteTest : IClassFixture<TestDependencyContext<Patient>>
    {
        private readonly FhirClient Client;
        private TestDependencyContext<Patient> context;
        public CreateUpdateDeleteTest(TestDependencyContext<Patient> context)
        {
            this.Client = context.Client;
            this.context = context;
        }

        [TestMetadata("CR01", "create a patient using xml")]
        [Theory, TestPriority(0)]
        [Fixture(false, "patient-example-no_references.xml")]
        public void CreatePersonUsingXml(Patient patient)
        {
            Client.PreferredFormat = ResourceFormat.Xml;
            Assert.Success(Client, () => patient = Client.Create(patient));
            Assert.LocationPresentAndValid(Client);

            // Create bevat geen response content meer. Terecht verwijderd?:
            // EK: Niet helemaal, er is weliswaar geen data meer gereturned, maar de headers (id, versie, modified) worden
            // nog wel geupdate
            Assert.ContentLocationValidIfPresent(Client);
            //TODO: delete this patient?
            context.Dependency = patient;
        }

        [TestMetadata("CR02", "create a patient using json")]
        [Theory, TestPriority(1)]
        [Fixture(false, "patient-example-no_references.xml")]
        public void CreatePersonUsingJson(Patient patient)
        {
            Client.PreferredFormat = ResourceFormat.Json;
            Assert.Success(Client, () => patient = Client.Create(patient));
            Assert.LocationPresentAndValid(Client);
            Assert.ContentLocationValidIfPresent(Client);
            context.Dependency = patient;
        }

        [TestMetadata("CR03", "create a patient using client-assigned id")]
        [Theory, TestPriority(2)]
        [Fixture(false, "patient-example-no_references.xml")]
        public void CreatePersonUsingClientAssignedId(Patient patient)
        {
            var rnd = new Random();
            string assignedId = "sprinkler" + rnd.Next();
            patient.Id = assignedId;
            //TODO: CorinaC - write test for this type of id if we decide to solve issue #19 (https://github.com/furore-fhir/spark/issues/19)
            //string assignedId = "7.345";
            var endpoint = new RestUrl(Client.Endpoint);
            Client.PreferredFormat = ResourceFormat.Xml;
            patient = Client.Update(patient);
            ResourceIdentity identity = patient.ResourceIdentity();

            Assert.AssertStatusCode(Client, HttpStatusCode.Created);
            Assert.IsTrue(endpoint.IsEndpointFor(identity),
                "Location of created resource is not located within server endpoint");
            Assert.IsTrue(identity.Id == assignedId, "Server refused to honor client-assigned id");

            context.Dependency = patient;
        }

        [TestMetadata("CR04", "Create a patient with manually assigned attributes")]
        [Theory, TestPriority(3)]
        [Fixture(false, "patient-example-no_references.xml")]
        public void CreatePatientWithAttributes(Patient patient)
        {
            var contactpoint = new ContactPoint();
            contactpoint.System = ContactPoint.ContactPointSystem.Email;
            contactpoint.Value = "selena_the_best@hotmail.com";
            patient.Telecom.Clear();
            patient.Telecom.Add(contactpoint);

            patient = Client.Create(patient);
            Assert.IsTrue(patient.Telecom.Count == 1, "Telecom component has disappeared on resource");
            context.Dependency = patient;
        }

        [TestMetadata("CR05", "Create and update a patient with an extension")]
        [Fact]
        public void CreateUpdatePatientWithExtension()
        {
            string extensionCode = "AC";
            string qualifier = "http://hl7.org/fhir/Profile/iso-21090#qualifier";

            Patient selena = CreatePatient(extensionCode, qualifier);
            var resource = Client.Create(selena);
            resource = Client.Read<Patient>(resource.ResourceIdentity());

            CheckHumanNameExtensions(resource.Contact[0].Name, qualifier, new[] { extensionCode },
                "Incorrect extensions found after creating resource" + resource.Id);

            UpdateHumanNameExtension(resource, "NB", qualifier);
            AddExtensionToHumanName(resource, "RT", qualifier);
            resource = Client.Update(resource);
            resource = Client.Read<Patient>(resource.ResourceIdentity());

            CheckHumanNameExtensions(resource.Contact[0].Name, qualifier, new[] { "NB", "RT" },
             "Incorrect extensions found after updating resource" + resource.Id);
        }

        private void CheckHumanNameExtensions(HumanName name, string qualifier,
         IEnumerable<string> expectedValues, string errorMessage)
        {
            IList<Extension> extensions = name.GetExtensions(qualifier).ToList();
            IList<string> extensionValues = extensions.Select(s => s.Value).OfType<Code>().Select(c => c.Value).ToList();
            foreach (string value in expectedValues)
            {
                if (!extensionValues.Contains(value))
                {
                    Assert.Fail(errorMessage);
                }
            }
        }

        [TestMetadata("CR06", "update the patient (no extensions altered)")]
        [Fact, TestPriority(4)]
        public void UpdatePersonWithoutExtensions()
        {
            if (context.Dependency == null) Assert.Skip();

            context.Dependency.Telecom.Add(new ContactPoint
            {
                System = ContactPoint.ContactPointSystem.Other,
                Value = "http://www.nu.nl"
            });

            Client.Update(context.Dependency);

            Patient patient = Client.Read<Patient>(context.Location);

            Assert.IsTrue(patient.Telecom.Any(
                tel => tel.System == ContactPoint.ContactPointSystem.Other && tel.Value == "http://www.nu.nl"),
                String.Format("Resource {0} unchanged after update", context.Location));
        }

        private  Patient CreatePatient(string extensionCode, string qualifier)
        {
            Patient selena = new Patient();
            Location location = null;

            var name = new HumanName();
            name.GivenElement.Add(new FhirString("selena"));
            name.FamilyElement.Add(new FhirString("Gomez"));
            selena.Name.Add(name);

            var address = new Address();
            address.LineElement.Add(new FhirString("Cornett"));
            address.CityElement = new FhirString("Amanda");
            address.CountryElement = new FhirString("United States");
            address.StateElement = new FhirString("Texas");
            selena.Address.Add(address);


            var contact = new Patient.ContactComponent();
            var contactname = new HumanName();
            contactname.GivenElement.Add(new FhirString("Martijn"));
            contactname.FamilyElement.Add(new FhirString("Harthoorn"));
            contactname.AddExtension(qualifier, new Code(extensionCode));
            contact.Name = contactname;
            selena.Contact.Add(contact);
            return selena;
        }

        private void UpdateHumanNameExtension(Patient patient, string extensionCode, string qualifier)
        {
            Extension qExt1 = patient.Contact[0].Name.GetExtension(qualifier);
            ((Code)qExt1.Value).Value = extensionCode;
        }

        private void AddExtensionToHumanName(Patient patient, string extensionCode, string qualifier)
        {
            patient.Contact[0].Name.AddExtension(qualifier, new Code(extensionCode));
        }

        [TestMetadata("CR07", "delete that person")]
        [Fact, TestPriority(5)]
        public void DeletePerson()
        {
            Assert.SkipWhen(context.Dependency == null);

            Client.Delete(context.Location);
            Assert.AssertStatusCode(Client, HttpStatusCode.NoContent);
            Assert.Fails(Client, () => Client.Read<Patient>(context.Location), HttpStatusCode.Gone);

            Client.Delete(context.Location);
            Assert.AssertStatusCode(Client, HttpStatusCode.NoContent, HttpStatusCode.OK);
        }

        [TestMetadata("CR08", "deletion of a non-existing resource")]
        [Fact]
        public void DeleteNonExistingPerson()
        {
            var rnd = new Random();
            Client.Delete(string.Format("{0}/{1}", ResourceType.Patient, rnd.Next()));

            Assert.AssertStatusCode(Client, HttpStatusCode.NoContent);
        }
    }
}