﻿using ControleDeUsuarios.Data;
using ControleDeUsuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeUsuarios.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            // gravar no banco de dados
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);
            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização do usuário");
            usuarioDB.Nome = usuario.Nome;
            usuarioDB.CPF = usuario.CPF;
            usuarioDB.DataNascimento = usuario.DataNascimento;
            usuarioDB.Email = usuario.Email;

            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na deleção do usuário");
            _bancoContext.Usuarios.Remove(usuarioDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}