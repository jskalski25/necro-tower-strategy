using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Input;

namespace NecroTower.GUI
{
    class ElementGroup : Element
    {
        private List<Element> elements;

        public ElementGroup() : base()
        {
            elements = new List<Element>();
        }

        public void Add(Element element)
        {
            elements.Add(element);
        }

        protected override void OnRender(Rectangle target, FrameEventArgs e)
        {
            base.OnRender(target, e);
            foreach (var element in elements)
            {
                element.Render(target, e);
            }
        }

        protected override void OnMouseDown(Rectangle target, MouseEventArgs e)
        {
            base.OnMouseDown(target, e);
            foreach (var element in elements)
            {
                element.MouseDown(target, e);
            }
        }
    }
}
