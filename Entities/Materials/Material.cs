using Common.Entity;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Materials
{
    public class Material : EntityBase
    {
        
        public string Bid { get; set; }

        public string ClassificationId { get; set; }

        public string OriginalMaterialId { get; set; }

        public string Name { get; set; }

        public string MaterialFamilyId { get; set; }

        public Hardness Hardness { get; set; }

        public string StandardId { get; set; }

        public string StandardTypeId { get; set; }

        public string StandardFilteringFullText { get; set; }

        public LastModified LastModified { get; set; }

        public bool IsDefaultMaterialDenomination { get; set; }
    }

    public class Hardness
    {
        public int HardnessValue { get; set; }

        public int ValueMin { get; set; }

        public int ValueMax { get; set; }

        public string HardnessUnit { get; set; }

    }

    public class LastModified
    {
        public DateTime DateTime { get; set; }

        public double Ticks { get; set; }

        public int Offset { get; set; }
    }
}
