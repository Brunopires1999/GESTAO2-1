using Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace BLL
{
    public class UsuarioBLL
    {
        public void Inserir(Usuario _usuario, string _confirmacaoSenha)
        {

            ValidarDados(_usuario, _confirmacaoSenha);
            Usuario usuario = new Usuario();

            usuario = BuscarUsuarioPorNome(_usuario.NomeUsuario);
            if (usuario.NomeUsuario == _usuario.NomeUsuario)
            {
                throw new Exception("Usuário já existente");
            }
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Inserir(_usuario);
        }
        private void ValidarDados(Usuario _usuario, string _confirmacaoSenha)
        {
            if (_usuario.NomeUsuario.Length <= 3 || _usuario.NomeUsuario.Length > 50) // length conta o numero de caracteres
            {
                throw new Exception("O nome de usuário deve ter mais de três caracteres.");
                //TODO:verificar se ja existe um usuário com este nome
            }

            if (_usuario.NomeUsuario.Contains(" ")) // Contains verifica se tem o caracteres dentro do parenteses no caso foi space
            {
                throw new Exception("O nome do usuário não pode ter espaços");

            }

            if (_usuario.Senha.Contains("1234567"))
            {
                throw new Exception("Não é permitido números em sequência");
            }

            if (_usuario.Senha.Length < 7 || _usuario.Senha.Length > 11)
            {
                throw new Exception("A senha deve ter entre 7 e 11 caracteres.");
            }
            if (_confirmacaoSenha != _usuario.Senha)
            {
                throw new Exception("O campo senha e a confirmação da senha não são iguais.");
            }
        }

        public void  AdicionarGrupo(int _idUsuario, int _idGrupo)
        {
            if (new UsuarioDAL().ExisteRelacionamento( _idUsuario, _idGrupo))
            {
                throw new Exception("Usuário já vinculado neste grupo");
            
            }
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.AdicionarGrupo(_idUsuario,  _idGrupo);

        }
        public Usuario BuscarUsuarioPorNome(string _nome_busca)
        {
            if (String.IsNullOrEmpty(_nome_busca))
            {
                throw new Exception("Informe o nome do usuário");
            }
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            return usuarioDAL.BuscarUsuarioPorNome(_nome_busca);

        }
        public Usuario BuscarUsuarioPorId(int _id_busca)
        {

            UsuarioDAL usuarioDAL = new UsuarioDAL();
            return usuarioDAL.BuscarUsuarioPorId(_id_busca);

        }



        public Usuario BuscarPorNomeAcesso(string _nome_busca)
        {
            if (String.IsNullOrEmpty(_nome_busca))
            {
                throw new Exception("Informe o nome do usuário");
            }
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            return usuarioDAL.BuscarPorNomeAcesso(_nome_busca);

        }

        public List<Usuario> BuscarTodos()

        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            return usuarioDAL.BuscarTodos();
        }

        public void Alterar(Usuario _alterarUsuario, string _confirmacaoSenha)
        {
            {

            /*
            if (_alterarUsuario.NomeUsuario.Length <= 3 || _alterarUsuario.NomeUsuario.Length > 50) // length conta o numero de caracteres
            {
                throw new Exception("O nome de usuário deve ter mais de três caracteres.");
                //TODO:verificar se ja existe um usuário com este nome
            }

            if (_alterarUsuario.NomeUsuario.Contains(" ")) // Contains verifica se tem o caracteres dentro do parenteses no caso foi space
            {
                throw new Exception("O nome do usuário não pode ter espaços");

            }

            if (_alterarUsuario.Senha.Contains("1234567"))
            {
                throw new Exception("Não é permitido números emm sequência");
            }

            if (_alterarUsuario.Senha.Length < 7 || _alterarUsuario.Senha.Length > 11)
            {
                throw new Exception("A senha deve ter entre 7 e 11 caracteres.");
            }
*/
            } //alteração não delete

            ValidarDados(_alterarUsuario, _confirmacaoSenha);

            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Alterar(_alterarUsuario);
        }
        public void Excluir(Usuario _id)
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Excluir(_id);
        }

        public void RemoverGrupoUsuario(int _id_usuario, int _id_grupo)
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.RemoverGrupoUsuario(_id_usuario, _id_grupo);
        }
    }
}