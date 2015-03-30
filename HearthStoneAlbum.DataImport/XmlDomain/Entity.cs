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
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Entity {

        private string masterPowerField;

        private EntityTag[] tagField;

        private EntityReferencedTag[] referencedTagField;

        private EntityPower[] powerField;

        private EntityTriggeredPowerHistoryInfo[] triggeredPowerHistoryInfoField;

        private string versionField;

        private string cardIDField;

        /// <remarks/>
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified)]
        public string MasterPower {
            get {
                return this.masterPowerField;
            }
            set {
                this.masterPowerField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("Tag", Form = XmlSchemaForm.Unqualified)]
        public EntityTag[] Tag {
            get {
                return this.tagField;
            }
            set {
                this.tagField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("ReferencedTag", Form = XmlSchemaForm.Unqualified)]
        public EntityReferencedTag[] ReferencedTag {
            get {
                return this.referencedTagField;
            }
            set {
                this.referencedTagField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("Power", Form = XmlSchemaForm.Unqualified)]
        public EntityPower[] Power {
            get {
                return this.powerField;
            }
            set {
                this.powerField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("TriggeredPowerHistoryInfo", Form = XmlSchemaForm.Unqualified)]
        public EntityTriggeredPowerHistoryInfo[] TriggeredPowerHistoryInfo {
            get {
                return this.triggeredPowerHistoryInfoField;
            }
            set {
                this.triggeredPowerHistoryInfoField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string CardID {
            get {
                return this.cardIDField;
            }
            set {
                this.cardIDField = value;
            }
        }
    }

}
