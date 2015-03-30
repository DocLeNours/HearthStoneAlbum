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
    public partial class EntityPower {

        private EntityPowerPlayRequirement[] playRequirementField;

        private string definitionField;

        /// <remarks/>
        [XmlElementAttribute("PlayRequirement", Form = XmlSchemaForm.Unqualified)]
        public EntityPowerPlayRequirement[] PlayRequirement {
            get {
                return this.playRequirementField;
            }
            set {
                this.playRequirementField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string definition {
            get {
                return this.definitionField;
            }
            set {
                this.definitionField = value;
            }
        }
    }

}
