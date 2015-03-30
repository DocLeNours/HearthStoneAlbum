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
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class EntityTag {

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
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified)]
        public string enUS {
            get {
                return this.enUSField;
            }
            set {
                this.enUSField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified)]
        public string frFR {
            get {
                return this.frFRField;
            }
            set {
                this.frFRField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified)]
        public string zhTW {
            get {
                return this.zhTWField;
            }
            set {
                this.zhTWField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified)]
        public string zhCN {
            get {
                return this.zhCNField;
            }
            set {
                this.zhCNField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified)]
        public string ruRU {
            get {
                return this.ruRUField;
            }
            set {
                this.ruRUField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified)]
        public string ptBR {
            get {
                return this.ptBRField;
            }
            set {
                this.ptBRField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified)]
        public string plPL {
            get {
                return this.plPLField;
            }
            set {
                this.plPLField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified)]
        public string koKR {
            get {
                return this.koKRField;
            }
            set {
                this.koKRField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified)]
        public string itIT {
            get {
                return this.itITField;
            }
            set {
                this.itITField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified)]
        public string esMX {
            get {
                return this.esMXField;
            }
            set {
                this.esMXField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified)]
        public string esES {
            get {
                return this.esESField;
            }
            set {
                this.esESField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified)]
        public string deDE {
            get {
                return this.deDEField;
            }
            set {
                this.deDEField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string enumID {
            get {
                return this.enumIDField;
            }
            set {
                this.enumIDField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }

}
