﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GiTracker.Resources.Strings {
    using System;
    using System.Reflection;
    
    
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
    public class IssueDetails {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal IssueDetails() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("GiTracker.Resources.Strings.IssueDetails", typeof(IssueDetails).GetTypeInfo().Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Assignee {0}.
        /// </summary>
        public static string AssignedTo {
            get {
                return ResourceManager.GetString("AssignedTo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Closed at {0:g}.
        /// </summary>
        public static string ClosedAt {
            get {
                return ResourceManager.GetString("ClosedAt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Created at {0:g}.
        /// </summary>
        public static string CreatedAt {
            get {
                return ResourceManager.GetString("CreatedAt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Created by {0}.
        /// </summary>
        public static string CreatedBy {
            get {
                return ResourceManager.GetString("CreatedBy", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Issue #{0}.
        /// </summary>
        public static string IssueNumber {
            get {
                return ResourceManager.GetString("IssueNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Updated at {0:g}.
        /// </summary>
        public static string UpdatedAt {
            get {
                return ResourceManager.GetString("UpdatedAt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to View in browser.
        /// </summary>
        public static string ViewInBrowser {
            get {
                return ResourceManager.GetString("ViewInBrowser", resourceCulture);
            }
        }
    }
}
