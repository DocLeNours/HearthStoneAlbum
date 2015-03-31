using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace HearthStoneAlbum.DataImport.XmlDomain {
    [GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute("Tag", AnonymousType = true)]
    public partial class Tag {

        private string enUSField;

        private string frFRField;

        private string zhTWField;

        private string zhCNField;

        private string ruRUField;

        private string ptBRField;

        private string plPLField;

        private string koKRField;

        private string itITField;

        private string esMXField;

        private string esESField;

        private string deDEField;

        private string nameField;

        private string enumIDField;

        private string typeField;

        private string valueField;

        /// <remarks/>
        [XmlElementAttribute("enUS", Form = XmlSchemaForm.Unqualified)]
        public string enUS {
            get {
                return this.enUSField;
            }
            set {
                this.enUSField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("frFR", Form = XmlSchemaForm.Unqualified)]
        public string frFR {
            get {
                return this.frFRField;
            }
            set {
                this.frFRField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("zhTW", Form = XmlSchemaForm.Unqualified)]
        public string zhTW {
            get {
                return this.zhTWField;
            }
            set {
                this.zhTWField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("zhCN", Form = XmlSchemaForm.Unqualified)]
        public string zhCN {
            get {
                return this.zhCNField;
            }
            set {
                this.zhCNField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("ruRU", Form = XmlSchemaForm.Unqualified)]
        public string ruRU {
            get {
                return this.ruRUField;
            }
            set {
                this.ruRUField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("ptBR", Form = XmlSchemaForm.Unqualified)]
        public string ptBR {
            get {
                return this.ptBRField;
            }
            set {
                this.ptBRField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("plPL", Form = XmlSchemaForm.Unqualified)]
        public string plPL {
            get {
                return this.plPLField;
            }
            set {
                this.plPLField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("koKR", Form = XmlSchemaForm.Unqualified)]
        public string koKR {
            get {
                return this.koKRField;
            }
            set {
                this.koKRField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("itIT", Form = XmlSchemaForm.Unqualified)]
        public string itIT {
            get {
                return this.itITField;
            }
            set {
                this.itITField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("esMX", Form = XmlSchemaForm.Unqualified)]
        public string esMX {
            get {
                return this.esMXField;
            }
            set {
                this.esMXField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("esES", Form = XmlSchemaForm.Unqualified)]
        public string esES {
            get {
                return this.esESField;
            }
            set {
                this.esESField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("deDE", Form = XmlSchemaForm.Unqualified)]
        public string deDE {
            get {
                return this.deDEField;
            }
            set {
                this.deDEField = value;
            }
        }

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
