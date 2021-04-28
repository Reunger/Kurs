using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursv1.Class
{
    public class ClassList:InterList
    {
        public string TextList_;
        string text_List;
        public ClassList()
        {
            text_List = TextList_;
            
        }
        public string text { get => text_List; set => text_List = value; }
    }
    public class Inf_class:Interface
    {
     
        public string Text;
        public string _va;
        public string _vb;
        public string _vc;
        public string _vd;

        string _Text;
        string va_;
        string vb_;
        string vc_;
        string vd_;

        public Inf_class()
        {
            _Text = Text;
            va_ = _va;
            vb_ = _vb;
            vc_ = _vc;
            vd_ = _vd;
            }
    
        
        public string vopros { get => _Text; set => _Text = value; }
        public string va { get => va_; set => va_ = value; }
        public string vb { get => vb_; set => vb_ = value; }
        public string vc { get => vc_; set => vc_ = value; }
        public string vd { get => vd_; set => vd_ = value; }
    }
}
