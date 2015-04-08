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

        private Tag FindTag(EnumId enumId) {
            string enumValue = ((int)enumId).ToString();
            return Tag.SingleOrDefault(t => t.EnumId == enumValue);
        }

        public bool Collectible {
            get {
                Tag collectible = FindTag(EnumId.Collectible);
                if (collectible == null) {
                    return false;
                }
                return collectible.Value == "1";
            }
        }

        private int? GetIntValue(EnumId enumId) {
            Tag tag = FindTag(enumId);
            if (tag != null) {
                int value;
                if (int.TryParse(tag.Data, out value)) {
                    return value;
                }
            }
            return null;
        }
        private string GetStringValue(EnumId enumId) {
            Tag tag = FindTag(enumId);
            if (tag != null) {
                return tag.Data;
            }
            return null;
        }
        public int? CardSetId { get { return this.GetIntValue(EnumId.CardSet); } }
        public int? HeroClassId { get { return this.GetIntValue(EnumId.Hero); } }
        public int? RarityId { get { return this.GetIntValue(EnumId.Rarity); } }
        public int? CardTypeId { get { return this.GetIntValue(EnumId.CardType); } }
        public int? RaceId { get { return this.GetIntValue(EnumId.Race); } }
        public int? Cost { get { return this.GetIntValue(EnumId.Cost); } }
        public int? Attack { get { return this.GetIntValue(EnumId.Attack); } }
        public int? Health { get { return this.GetIntValue(EnumId.Health); } }
        public int? Durability { get { return this.GetIntValue(EnumId.Durability); } }
        public string CardName { get { return this.GetStringValue(EnumId.CardName); } }
        public string CardText { get { return this.GetStringValue(EnumId.CardText); } }
    }
}
