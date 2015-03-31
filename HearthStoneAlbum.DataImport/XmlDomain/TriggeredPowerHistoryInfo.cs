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
    [XmlTypeAttribute("TriggeredPowerHistoryInfo", AnonymousType = true)]
    public partial class TriggeredPowerHistoryInfo {

        private string effectIndexField;

        private string showInHistoryField;

        /// <remarks/>
        [XmlAttributeAttribute("effectIndex")]
        public string EffectIndex {
            get {
                return this.effectIndexField;
            }
            set {
                this.effectIndexField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute("showInHistory")]
        public string ShowInHistory {
            get {
                return this.showInHistoryField;
            }
            set {
                this.showInHistoryField = value;
            }
        }
    }
}
