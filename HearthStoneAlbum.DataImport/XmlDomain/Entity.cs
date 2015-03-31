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
    [XmlRootAttribute("Entity", Namespace = "", IsNullable = false)]
    public partial class Entity {

        private string masterPowerField;

        private Tag[] tagField;

        private ReferencedTag[] referencedTagField;

        private Power[] powerField;

        private TriggeredPowerHistoryInfo[] triggeredPowerHistoryInfoField;

        private EntourageCard[] entourageCardField;

        private string versionField;

        private string cardIDField;

        /// <remarks/>
        [XmlElementAttribute("MasterPower", Form = XmlSchemaForm.Unqualified)]
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
        public Tag[] Tags {
            get {
                return this.tagField;
            }
            set {
                this.tagField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("ReferencedTag", Form = XmlSchemaForm.Unqualified)]
        public ReferencedTag[] ReferencedTags {
            get {
                return this.referencedTagField;
            }
            set {
                this.referencedTagField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("Power", Form = XmlSchemaForm.Unqualified)]
        public Power[] Powers {
            get {
                return this.powerField;
            }
            set {
                this.powerField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("TriggeredPowerHistoryInfo", Form = XmlSchemaForm.Unqualified)]
        public TriggeredPowerHistoryInfo[] TriggeredPowerHistoryInfos {
            get {
                return this.triggeredPowerHistoryInfoField;
            }
            set {
                this.triggeredPowerHistoryInfoField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("EntourageCard", Form = XmlSchemaForm.Unqualified)]
        public EntourageCard[] EntourageCards {
            get {
                return this.entourageCardField;
            }
            set {
                this.entourageCardField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute("version")]
        public string Version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute("CardID")]
        public string CardId {
            get {
                return this.cardIDField;
            }
            set {
                this.cardIDField = value;
            }
        }

        public Tag GetTag(string tagName) {
            return this.Tags.SingleOrDefault(t => t.Name.Equals(tagName, StringComparison.InvariantCultureIgnoreCase));
        }
    }

}
