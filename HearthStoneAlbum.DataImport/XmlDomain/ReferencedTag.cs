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
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class ReferencedTag {

        private string nameField;

        private string enumIDField;

        private string typeField;

        private string valueField;

        /// <remarks/>
        [XmlAttributeAttribute("name")]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute("enumID")]
        public string EnumId {
            get {
                return this.enumIDField;
            }
            set {
                this.enumIDField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute("type")]
        public string Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute("value")]
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
}
