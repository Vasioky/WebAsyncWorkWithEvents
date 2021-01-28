using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text.Json.Serialization;

namespace WebAPI1.Models
{
    public class Batch : BaseEntity
    {
        [NotMapped]
        public IEnumerable<int> Items
        {
            get
            {
                var tab = InternalData?.Split(',')?? new string[] { };
                return tab.Select(int.Parse).AsEnumerable();
            }
            set { InternalData = string.Join(",", value); }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonIgnore]
        public string InternalData { get; set; }

        public decimal? Result { get; set; }
    }
}
