using Lesson_1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson_1.Models
{

    public class ValuesHolder<T> : IEnumerable<T>
    {

        public List<T> Values { get; set; }

        public ValuesHolder() => Values = new List<T>();

        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)Values).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)Values).GetEnumerator();

    }
}
