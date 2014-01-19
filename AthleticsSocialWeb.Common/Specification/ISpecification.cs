using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthleticsSocialWeb.Common.Specification
{
    /// <summary>
    /// Base contract for Specification pattern with Linq and
    /// lambda expression support
    /// Ref : http://martinfowler.com/apsupp/spec.pdf
    /// Ref : http://en.wikipedia.org/wiki/Specification_pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISpecification<in T>
    {

        bool IsSatisfiedBy(T t);
    }
}
