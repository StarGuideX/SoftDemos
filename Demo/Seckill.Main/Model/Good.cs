using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seckill.Main.Model
{
    public class Good
    {
        private string _indexUrl;
        private string _goodUrl;
        private GoodType _type;
        public string GoodUrl
        {
            get
            {
                return _goodUrl;
            }

            set
            {
                _goodUrl = value;
            }
        }
        public GoodType Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public string IndexUrl
        {
            get
            {
                return _indexUrl;
            }

            set
            {
                _indexUrl = value;
            }
        }
    }
}
