﻿using System;
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
    public partial class Entity {

        private string masterPowerField;

        private Tag[] tagField;

        private ReferencedTag[] referencedTagField;

        private Power[] powerField;

        private EntourageCard[] entourageCardField;

        private TriggeredPowerHistoryInfo[] triggeredPowerHistoryInfoField;

        private string versionField;

        private string cardIDField;

        /// <remarks/>
        [XmlElementAttribute("MasterPower", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string MasterPower {
            get {
                return this.masterPowerField;
            }
            set {
                this.masterPowerField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("Tag", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public Tag[] Tag {
            get {
                return this.tagField;
            }
            set {
                this.tagField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("ReferencedTag", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ReferencedTag[] ReferencedTag {
            get {
                return this.referencedTagField;
            }
            set {
                this.referencedTagField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("Power", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Power[] Power {
            get {
                return this.powerField;
            }
            set {
                this.powerField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("EntourageCard", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public EntourageCard[] EntourageCard {
            get {
                return this.entourageCardField;
            }
            set {
                this.entourageCardField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("TriggeredPowerHistoryInfo", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public TriggeredPowerHistoryInfo[] TriggeredPowerHistoryInfo {
            get {
                return this.triggeredPowerHistoryInfoField;
            }
            set {
                this.triggeredPowerHistoryInfoField = value;
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
    }
}
