﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Furore.Fhir.Sprinkler.CLI.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Furore.Fhir.Sprinkler.CLI.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Available modules and codes:
        ///.
        /// </summary>
        internal static string availableModules {
            get {
                return ResourceManager.GetString("availableModules", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error: {0}.
        /// </summary>
        internal static string error {
            get {
                return ResourceManager.GetString("error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Missing mandatory Fhir-server URL..
        /// </summary>
        internal static string ErrorUrlmissing {
            get {
                return ResourceManager.GetString("ErrorUrlmissing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Wrong value for parameter {0}:{1}.
        /// </summary>
        internal static string ErrorWrongValueForParameter {
            get {
                return ResourceManager.GetString("ErrorWrongValueForParameter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to format: -f:Xml | -f:Html | -f:Raw (optional. Default: Raw output).
        /// </summary>
        internal static string HelpForFormatParameter {
            get {
                return ResourceManager.GetString("HelpForFormatParameter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to list all available modules and tests.
        /// </summary>
        internal static string HelpForListParameter {
            get {
                return ResourceManager.GetString("HelpForListParameter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to output path with filename (optional. Default: output to console).
        /// </summary>
        internal static string HelpForOutputPararameter {
            get {
                return ResourceManager.GetString("HelpForOutputPararameter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;command&gt; test | script | list
        ///	&lt;url&gt;	The URL address of the FHIR server
        ///	&lt;codes&gt;	A space-separated list of the test-modules or test-codes to execute.
        ///		(optional. Default: all tests will be executed)..
        /// </summary>
        internal static string HelpForParameters {
            get {
                return ResourceManager.GetString("HelpForParameters", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;command&gt; &lt;url&gt; [&lt;codes&gt;] [-options].
        /// </summary>
        internal static string HelpForSyntax {
            get {
                return ResourceManager.GetString("HelpForSyntax", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usage:
        ///	{0} {1}.
        /// </summary>
        internal static string HelpForUsage {
            get {
                return ResourceManager.GetString("HelpForUsage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Test started, please wait....
        /// </summary>
        internal static string MessageTestStarted {
            get {
                return ResourceManager.GetString("MessageTestStarted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///Options:.
        /// </summary>
        internal static string options {
            get {
                return ResourceManager.GetString("options", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///Parameters:.
        /// </summary>
        internal static string parameters {
            get {
                return ResourceManager.GetString("parameters", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sprinkler v0.6 - Conformance test suite for FHIR 0.8 (DSTU1).
        /// </summary>
        internal static string ProgramTitle {
            get {
                return ResourceManager.GetString("ProgramTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///{0}
        ///Tested module:[{1}] method:[{2}].
        /// </summary>
        internal static string statusForCategoryCode {
            get {
                return ResourceManager.GetString("statusForCategoryCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;xsl:stylesheet version=&quot;1.0&quot; xmlns:xsl=&quot;http://www.w3.org/1999/XSL/Transform&quot;&gt;
        ///  &lt;xsl:output method=&quot;html&quot; doctype-system=&quot;about:legacy-compat&quot; encoding=&quot;UTF-8&quot; indent=&quot;yes&quot; /&gt;
        ///
        ///  &lt;xsl:template match=&quot;Title&quot; /&gt;
        ///
        ///  &lt;xsl:template match=&quot;TestResults&quot;&gt;
        ///    &lt;html&gt;
        ///      &lt;head&gt;
        ///        &lt;title&gt;
        ///          &lt;xsl:value-of select=&quot;Title&quot; /&gt;
        ///        &lt;/title&gt;
        ///        &lt;style&gt;
        ///          body {font-family: Arial;}
        ///          h1, h2 {color: sienna; margin-bottom: 0;}
        ///     [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string xmlToHtml {
            get {
                return ResourceManager.GetString("xmlToHtml", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;xsl:stylesheet version=&quot;1.0&quot; xmlns:xsl=&quot;http://www.w3.org/1999/XSL/Transform&quot;&gt;
        ///  &lt;xsl:output method=&quot;html&quot; doctype-system=&quot;about:legacy-compat&quot; encoding=&quot;UTF-8&quot; indent=&quot;yes&quot; /&gt;
        ///  &lt;xsl:variable name=&quot;newline&quot; select=&quot;&apos;&amp;#10;&apos;&quot;/&gt;
        ///  &lt;xsl:variable name=&quot;indent&quot;&gt;&lt;xsl:value-of select=&quot;$newline&quot;/&gt;   - &lt;/xsl:variable&gt;
        ///  &lt;xsl:template match=&quot;Title&quot; /&gt;
        ///  &lt;xsl:template match=&quot;TestResult&quot;&gt;&lt;xsl:value-of select=&quot;Code&quot; /&gt;: &lt;xsl:value-of select=&quot;Title&quot; /&gt; : &lt;xsl:value-of select= [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string xmlToRaw {
            get {
                return ResourceManager.GetString("xmlToRaw", resourceCulture);
            }
        }
    }
}