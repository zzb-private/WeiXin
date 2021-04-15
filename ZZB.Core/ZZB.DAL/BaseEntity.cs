using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZB.DAL
{
    public interface IEntity
    {
        object[] GetKeys();
    }
    public interface IEntity<TKey> : IEntity
    {
        TKey Id { get; }
    }
    public class BaseEntity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }

        public string CrtUser { get; set; }
        public string ModifyUser { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public DateTime? ModifyDate { get; set; } = DateTime.Now;

        public object[] GetKeys()
        {
            throw new NotImplementedException();
        }
    }

    public class IntEntity : BaseEntity<int>
    {
    }
    public class StringEntity : BaseEntity<string>
    {
    }
}
