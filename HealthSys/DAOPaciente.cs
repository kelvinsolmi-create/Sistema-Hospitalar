using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using MySql.Data.MySqlClient; //Importando os comandos de conexão com o banco

using System.Windows.Forms;//Importando a estrutura de telas
 
namespace HealthSys___Sistema_Hospitalar

{

     class DAOPaciente

    {

        public MySqlConnection conexao;//Criando a variável que representa o banco

        public string dados;

        public string comando;

        public int[] codigo;

        public string[] nome;

        public string[] genero;

        public long[] CPF;

        public string[] email;

        public DateTime[] dtNascimento;

        public string[] telefone;

        public string[] endereco;

        public string[] convenio;

        public int i;

        public int contar;

        public string msg;
 
        public DAOPaciente()

        {

            conexao = new MySqlConnection("server=localhost;DataBase=sistemahospitlar;Uid=root;Password=;Conver Zero DateTime=True");

            try

            {

                this.conexao.Open();//Abrir a conexão

            }

            catch (Exception erro)

            {

                MessageBox.Show($"Algo deu errado!\n\n {erro}");

                this.conexao.Close();//Fechar a conexão com o BD

            }//fim do try_catch

        }//fim do construtor
 
        //Preencher Vetor --> Coletar os dados do banco e preenhcer o vetor

        public void PreencherVetor()

        {

            string query = "select * from paciente";//Buscando todos os dados da tabela autor

            //Instanciar os vetores

            this.codigo = new int[100];

            this.nome = new string[100];

            this.genero = new string[100];

            this.CPF = new long[100];

            this.email = new string[100];

            this.dtNascimento = new DateTime[100];

            this.telefone = new string[100];

            this.endereco = new string[100];

            this.convenio = new string[100];
 
            //Preencher os vetores com valores padrões

            for (i = 0; i < 100; i++)

            {

                this.codigo[i] = 0;

                this.nome[i] = "";

                this.genero[i] = "";

                this.CPF[i] = 0;

                this.email[i] = "";

                this.dtNascimento[i] = DateTime.Now;

                this.telefone[i] = "";

                this.endereco[i] = "";

                this.convenio[i] = "";

            }//fim do for
 
            //Executar o comando do SQL

            MySqlCommand coletar = new MySqlCommand(query, this.conexao);
 
            //Leitura do dado no banco

            MySqlDataReader leitura = coletar.ExecuteReader();//Percorre o banco e traz os dados    
 
            //Zerar o contador

            i = 0;

            this.contar = 0;

            while (leitura.Read())

            {

                this.codigo[i] = Convert.ToInt32(leitura["codigo"]);

                this.nome[i] = leitura["nome"] + "";

                this.genero[i] = leitura["genero"] + "";

                this.CPF[i] = Convert.ToInt32(leitura["CPF"]);

                this.email[i] = leitura["email"] + "";

                this.dtNascimento[i] = Convert.ToDateTime(leitura["dtNascimento"]);

                this.telefone[i] = leitura["telefone"] + "";

                this.endereco[i] = leitura["endereco"] + "";

                this.convenio[i] = leitura["convenio"] + "";

                i++;

                this.contar++;//Informar quantos dados tem no banco

            }//fim do while
 
            leitura.Close();//Encerrando o processo de busca

        }//fim do método
 
        public string ConsultarTudo()

        {

            PreencherVetor();//Preencher todos os dados do vetor

            this.msg = "";

            for (i = 0; i < this.contar; i++)

            {

                this.msg += $"\nCódigo:               {this.codigo[i]} " +

                            $"\nNome:                 {this.nome[i]} " +

                            $"\nGênero:               {this.genero[i]}" +

                            $"\nCPF:                  {this.CPF[i]}" +

                            $"\nEmail:                {this.email[i]}" +

                            $"\nData de Nascimento:   {this.dtNascimento[i]}" +

                            $"\nTelefone:             {this.telefone[i]}" +

                            $"\nEndereço:             {this.endereco[i]}" +

                            $"\nConvênio:             {this.convenio[i]}\n\n";

            }

            return this.msg;

        }//fim do método consultarTudo
 
        public string ConsultarPorCodigo(int codigo)

        {

            PreencherVetor();//Preencher todos os dados do vetor

            this.msg = "";

            for (i = 0; i < this.contar; i++)

            {

                if (this.codigo[i] == codigo)

                {

                    this.msg = $"\nCódigo:               {this.codigo[i]} "       +

                               $"\nNome:                 {this.nome[i]} "         +

                               $"\nGênero:               {this.genero[i]}"        +

                               $"\nCPF:                  {this.CPF[i]}"           +     

                               $"\nEmail:                {this.email[i]}"         +

                               $"\nData de Nascimento:   {this.dtNascimento[i]}"  +

                               $"\nTelefone:             {this.telefone[i]}"      +

                               $"\nEndereço:             {this.endereco[i]}"      +

                               $"\nConvênio:             {this.convenio[i]}\n\n";

                    return this.msg;

                }//fim do if              

            }//fim do for

            return "Código informado não existe!";

        }//fim do método consultarPorCodigo
 
        public string ConsultarNome(int codigo)

        {

            PreencherVetor();//Preencher todos os dados do vetor
 
            for (i = 0; i < this.contar; i++)

            {

                if (this.codigo[i] == codigo)

                {

                    return this.nome[i];

                }//fim do if              

            }//fim do for

            return "Código informado não existe!";

        }//fim do método consultarNome
 
        public string ConsultarGenero(int codigo)

        {

            PreencherVetor();//Preencher todos os dados do vetor
 
            for (i = 0; i < this.contar; i++)

            {

                if (this.codigo[i] == codigo)

                {

                    return this.genero[i];

                }//fim do if              

            }//fim do for

            return "Código informado não existe!";

        }//fim do método consultarGenero
 
        public string ConsultarCPF(int codigo)

        {

            PreencherVetor();//Preencher todos os dados do vetor
 
            for (i = 0; i < this.contar; i++)

            {

                if (this.codigo[i] == codigo)

                {

                    return this.CPF[i].ToString();

                }//fim do if              

            }//fim do for

            return "Código informado não existe!";

        }//fim do método consultarCPF
 
        public string ConsultarEmail(int codigo)

        {

            PreencherVetor();//Preencher todos os dados do vetor
 
            for (i = 0; i < this.contar; i++)

            {

                if (this.codigo[i] == codigo)

                {

                    return this.email[i];

                }//fim do if              

            }//fim do for

            return "Código informado não existe!";

        }//fim do método consultarEmail
 
        public string ConsultarDtNascimento(int codigo)

        {

            PreencherVetor();//Preencher todos os dados do vetor
 
            for (i = 0; i < this.contar; i++)

            {

                if (this.codigo[i] == codigo)

                {

                    return this.dtNascimento[i].ToString(); 

                }//fim do if              

            }//fim do for

            return "Código informado não existe!";

        }//Fim do método consultarDtNascimento
 
        public string ConsultarTelefone(int codigo)

        {

            PreencherVetor();//Preencher todos os dados do vetor
 
            for (i = 0; i < this.contar; i++)

            {

                if (this.codigo[i] == codigo)

                {

                    return this.telefone[i];

                }//fim do if              

            }//fim do for

            return "Código informado não existe!";

        }//fim do método consultarTelefone
 
        public string ConsultarEndereco(int codigo)

        {

            PreencherVetor();//Preencher todos os dados do vetor
 
            for (i = 0; i < this.contar; i++)

            {

                if (this.codigo[i] == codigo)

                {

                    return this.endereco[i];

                }//fim do if              

            }//fim do for

            return "Código informado não existe!";

        }//fim do método consultarEndereco
 
        public string ConsultarConvenio(int codigo)

        {

            PreencherVetor();//Preencher todos os dados do vetor
 
            for (i = 0; i < this.contar; i++)

            {

                if (this.codigo[i] == codigo)

                {

                    return this.convenio[i];

                }//fim do if              

            }//fim do for

            return "Código informado não existe!";

        }//fim do método consultarConvênio
 
        public string Atualizar(int codigo, string campo, string novoDado)

        {

            try

            {

                string query = $"update autor set {campo} = '{novoDado}' where codigo = '{codigo}'";

                //Executar o comando

                MySqlCommand sql = new MySqlCommand(query, this.conexao);

                string resultado = "" + sql.ExecuteNonQuery();//Comando de inserção no banco

                return $"Atualizado com sucesso\n\n {resultado}";

            }

            catch (Exception erro)

            {

                return $"Algo deu errado\n\n {erro}";

            }

        }//fim do atualizar
 
        public string Deletar(int codigo)

        {

            try

            {

                string query = $"delete from autor where codigo = '{codigo}'";

                //Executar o comando

                MySqlCommand sql = new MySqlCommand(query, this.conexao);

                string resultado = "" + sql.ExecuteNonQuery();//Comando de inserção no banco

                return $"Deletado com sucesso\n\n {resultado}";

            }

            catch (Exception erro)

            {

                return $"Algo deu errado\n\n {erro}";

            }

        }//fim do deletar
 
    }//Fim da Classe DAOPaciente

}//Fim do Projeto 

 