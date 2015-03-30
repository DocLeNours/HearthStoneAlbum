using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HearthStoneAlbum.DataImport.XmlDomain {
    [GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class EntityTriggeredPowerHistoryInfo {

        private string effectIndexField;

        private string showInHistoryField;

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string effectIndex {
            get {
                return this.effectIndexField;
            }
            set {
                this.effectIndexField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string showInHistory {
            get {
                return this.showInHistoryField;
            }
            set {
                this.showInHistoryField = value;
            }
        }
    }
}
