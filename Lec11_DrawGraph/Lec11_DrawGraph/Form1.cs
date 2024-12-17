using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lec11_DrawGraph
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private Pen penVertex;
        private Pen penVertexSelected;
        private Pen penEdge;
        private Brush brushId;
        private const int vertexRadius = 20;

        private Graph myGraph;

        private Graph.Vertex selectedVertex = null;

        public Form1()
        {
            InitializeComponent();
            myGraph = new Graph();
            pictureBoxGraphVisualization.Image = new Bitmap(pictureBoxGraphVisualization.Width,
                                                            pictureBoxGraphVisualization.Height);
            graphics = Graphics.FromImage(pictureBoxGraphVisualization.Image);
            penVertex = new Pen(Color.Red, 2);
            penVertexSelected = new Pen(Color.Red, 5);
            penEdge = new Pen(Color.Blue, 2);
            brushId = new SolidBrush(Color.Red);

            DrawGraph();
        }

        private void pictureBoxGraphVisualization_MouseDown(object sender, MouseEventArgs e)
        {
            //add or move vertex
            if (e.Button == MouseButtons.Left)
            {
                foreach (Graph.Vertex v in myGraph.Vertices)
                {
                    //move
                    if (v.Distance(e.Location) < vertexRadius)
                    {
                        selectedVertex = v;
                        DrawGraph();
                        return;
                    }
                    //to close
                    else if (v.Distance(e.Location) < vertexRadius * 2)
                    {
                        return;
                    }
                }
                //add
                myGraph.AddVertex(e.Location);
                DrawGraph();
            }
            //select and add egde
            else if (e.Button == MouseButtons.Right)
            {
                foreach (Graph.Vertex v in myGraph.Vertices)
                {
                    if (v.Distance(e.Location) < vertexRadius)
                    {
                        //select first veretx
                        if (selectedVertex == null)
                        {
                            selectedVertex = v;
                        }
                        //add edge
                        else
                        {
                            myGraph.AddEdge(selectedVertex, v);
                            selectedVertex = null;
                        }
                        DrawGraph();
                    }
                }
            }
        }
        private void pictureBoxGraphVisualization_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && selectedVertex != null)
            {
                foreach (Graph.Vertex v in myGraph.Vertices)
                {
                    if (v != selectedVertex && v.Distance(e.Location) < vertexRadius * 2)
                    {
                        selectedVertex = null;
                        DrawGraph();
                        return;
                    }
                }
                selectedVertex.Location = e.Location;
                DrawGraph();
            }
        }
        private void pictureBoxGraphVisualization_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectedVertex = null;
                DrawGraph();
            }
        }
        private void DrawGraph()
        {
            graphics.Clear(Color.White);
            foreach (Graph.Vertex v in myGraph.Vertices)
            {
                graphics.DrawEllipse((v == selectedVertex) ? penVertexSelected : penVertex,
                                     v.Location.X - vertexRadius,
                                     v.Location.Y - vertexRadius,
                                     vertexRadius * 2,
                                     vertexRadius * 2);

                graphics.DrawString(v.Id.ToString(),
                                    new Font("Arial", vertexRadius),
                                    brushId,
                                    v.Location.X + vertexRadius,
                                    v.Location.Y + vertexRadius);
            }
            foreach (Graph.Edge e in myGraph.Edges)
            {
                graphics.DrawLine(penEdge,
                                  e.V1.Location,
                                  e.V2.Location);
            }
            pictureBoxGraphVisualization.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && selectedVertex != null)
            {
                myGraph.RemoveVertex(selectedVertex);
                selectedVertex = null;
                DrawGraph();
            }
        }
    }
}
