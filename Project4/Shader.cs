﻿using System.IO;
using System.Text;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Project4
{
    class Shader
    {
        public readonly int ProgramID;

        private readonly int _vertexLocation;

        private readonly int _projectionMatrixLocation;
        private readonly int _modelviewMatrixLocation;

        private Matrix4 _projectionMatrix;
        private Matrix4 _modelviewMatrix;

        public Shader(string vertexPath, string fragmentPath)
        {
            var vertexShaderSource = LoadSource(vertexPath);
            var vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, vertexShaderSource);
            GL.CompileShader(vertexShader);

            var fragmentShaderSource = LoadSource(fragmentPath);
            var fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, fragmentShaderSource);
            GL.CompileShader(fragmentShader);

            ProgramID = GL.CreateProgram();

            GL.AttachShader(ProgramID, vertexShader);
            GL.AttachShader(ProgramID, fragmentShader);

            GL.LinkProgram(ProgramID);

            GL.DetachShader(ProgramID, vertexShader);
            GL.DetachShader(ProgramID, fragmentShader);
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);

            _vertexLocation = GL.GetAttribLocation(ProgramID, "aPosition");

            _projectionMatrixLocation = GL.GetUniformLocation(ProgramID, "uProjectionMatrix");
            _modelviewMatrixLocation = GL.GetUniformLocation(ProgramID, "uModelviewMatrix");
        }

        private static string LoadSource(string path)
        {
            using (var sr = new StreamReader(path, Encoding.UTF8))
            {
                return sr.ReadToEnd();
            }
        }

        public void Free()
        {
            GL.DeleteProgram(ProgramID);
        }

        public void Bind()
        {
            GL.UseProgram(ProgramID);
        }

        public void SetVertexPointer(int stride, int offset)
        {
            GL.VertexAttribPointer(_vertexLocation, 2, VertexAttribPointerType.Float, false, stride, offset);
        }

        public void EnableVertexPointer()
        {
            GL.EnableVertexAttribArray(_vertexLocation);
        }

        public void SetProjection(Matrix4 matrix)
        {
            _projectionMatrix = matrix;
        }

        public void SetModelview(Matrix4 matrix)
        {
            _modelviewMatrix = matrix;
        }

        public void MultProjection(Matrix4 matrix)
        {
            _projectionMatrix = matrix * _projectionMatrix;
        }

        public void MultModelview(Matrix4 matrix)
        {
            _modelviewMatrix = matrix * _modelviewMatrix;
        }

        public void UpdateProjection()
        {
            GL.UniformMatrix4(_projectionMatrixLocation, false, ref _projectionMatrix);
        }

        public void UpdateModelview()
        {
            GL.UniformMatrix4(_modelviewMatrixLocation, false, ref _modelviewMatrix);
        }
    }
}
