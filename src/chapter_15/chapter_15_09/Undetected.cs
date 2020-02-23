using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_15_09
{
    struct Undetected
    {
        private IDictionary<string, object> _bag;
        public Undetected(IDictionary<string, object> bag)
        {
            _bag = bag;
        }
        public readonly string Description
        {
            get => (string)_bag["Description"];
            set => _bag["Description"] = value;
        }
    }

}
