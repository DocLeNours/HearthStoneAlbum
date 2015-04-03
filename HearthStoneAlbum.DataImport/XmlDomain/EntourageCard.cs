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
    public partial class EntourageCard {

        private string cardIDField;

        /// <remarks/>
        [XmlAttributeAttribute("cardID")]
        public string CardId {
            get {
                return this.cardIDField;
            }
            set {
                this.cardIDField = value;
            }
        }
    }
}
