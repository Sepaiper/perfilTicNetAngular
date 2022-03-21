using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.Presenter
{
    public interface IPresenter<FormDataType>
    {
        public FormDataType Content { get; }
    }
}
