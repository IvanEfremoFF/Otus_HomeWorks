using System;

namespace CustomDictionary
{
    class OtusDictionary
    {
        private (int key, string value)[] _values;
        private int _size = 8;

        public OtusDictionary()
        {
            _values = new (int key, string value)[_size];
        }

        public string this[int index]
        {
            get
            {
                if (index > _size)
                {
                    return $"dictionary has {_size} elements. it's more than entered {index}";
                };

                return _values[index].value ?? "Element by the index not found";
            }
        }


        public void Add(int key, string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Value is null");
            }

            var isKeyExist = _values[GetHash(key, _size)].key == key;

            if (isKeyExist)
            {
                return;
            }

            while (!TryAdd(key, value))
            {                
                ExtendAndRecalculate(_size * 2);
            };
        }

        private void ExtendAndRecalculate(int newSize)
        {
            var oldSize = _size;
            var newValues = new (int key, string value) [newSize];

            for (int i = 0; i < oldSize; i++)
            {
                var isValueEmpty = string.IsNullOrEmpty(_values[i].value) && _values[i].key == 0;
                if (isValueEmpty)
                {
                    continue;
                }

                var newIndex = GetHash(_values[i].key, newSize);
                newValues[newIndex] = _values[i];
            }
            _values = newValues;
            _size = newSize;
        }

        private bool TryAdd(int key, string value)
        {
            var index = GetHash(key, _size);
            var isValueEmpty = string.IsNullOrEmpty(_values[index].value) && _values[index].key == 0;

            if (isValueEmpty)
            {
                _values[index].value = value;
                _values[index].key = key;
                return true;
            }
            return false;            
        }

        public string Get(int key)
        {
            var index = GetHash(key, _size);
            return index <= _size ? _values[index].value : null! ;
        }

        private int GetHash(int key, int size)
        {
            return key % size;
        }
    }
}
