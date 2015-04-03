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
    public partial class PlayRequirement {

        private string reqIDField;

        private string paramField;

        /// <remarks/>
        [XmlAttributeAttribute("reqID")]
        public string ReqId {
            get {
                return this.reqIDField;
            }
            set {
                this.reqIDField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute("param")]
        public string Param {
            get {
                return this.paramField;
            }
            set {
                this.paramField = value;
            }
        }
    }
}
