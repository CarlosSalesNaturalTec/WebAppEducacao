using System;
using System.Text;

public partial class CAD_Municipio_Ficha : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    string idAux;

    protected void Page_Load(object sender, EventArgs e)
    {

        idAux = Request.QueryString["v1"];
        PreencheCampos(idAux);
        listaUsuarios(idAux);

    }


    private void PreencheCampos(string ID)
    {
        string ScriptDados = "";
        str.Clear();

        ScriptDados = "<script type=\"text/javascript\">";
        str.Append(ScriptDados);
        ScriptDados = "var x = document.getElementsByClassName('form-control');";
        str.Append(ScriptDados);

        // <!--*******Customização. adicionar todos os campos, separados um em cada linha*******-->
        string stringSelect = "select Nome, UF, Gestor, Telefone, Email, Endereco , Latitude , Longitude , Logomarca " +
            "from Tbl_Municipios  " +
            "where ID_Munic = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            for (int i = 0; i < 8; i++)  // <!--*******Customização*******--> Atenção para quantidade de campos. Ex: neste formulario tenho 9 campos 
            {
                ScriptDados = "x[" + i + "].value = \"" + Convert.ToString(rcrdset[i]) + "\";";
                str.Append(ScriptDados);
            }

            //monta foto            
            ScriptDados = "document.getElementById('results').innerHTML = '<img src=\"" + Convert.ToString(rcrdset[8]) + "\"/>'; ";
            str.Append(ScriptDados);
            ScriptDados = "document.getElementById('FotoHidden').value = \"" + Convert.ToString(rcrdset[8]) + "\";";
            str.Append(ScriptDados);

            //ID do registro
            ScriptDados = "document.getElementById('IDAuxHidden').value = \"" + ID + "\";";
            str.Append(ScriptDados);

            // mapa
            ScriptDados = "var latitude = document.getElementById('input_lat').value;";
            str.Append(ScriptDados);

            ScriptDados = "var longitude = document.getElementById('input_lng').value;";
            str.Append(ScriptDados);

            ScriptDados = "var urlMapa = \"MapaAuxiliar.aspx?lat=\" + latitude + \"&lng=\" + longitude;";
            str.Append(ScriptDados);

            ScriptDados = "window.open(urlMapa, 'MapFrame');";
            str.Append(ScriptDados);
        }
        ConexaoBancoSQL.fecharConexao();

        ScriptDados = "</script>";
        str.Append(ScriptDados);

        Literal1.Text = str.ToString();
    }

    private void listaUsuarios(string ID)
    {

        string stringSelect = "select ID_user, Nome, usuario from tbl_usuarios" +
            " where ID_Munic = " + ID +
            " order by Nome";
        OperacaoBanco operacaoUsers = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdsetUsers = operacaoUsers.Select(stringSelect);

        str.Clear();
        string ScriptDados;

        while (rcrdsetUsers.Read())
        {

            string bt1 = "<a class='w3-btn w3-round w3-hover-red w3-text-green' onclick='ExcluirUser(this," +
                Convert.ToString(rcrdsetUsers[0]) +
                ")'><i class='fa fa-trash-o' aria-hidden='true'></i></a>&nbsp;&nbsp;";

            ScriptDados = "<tr>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + bt1 + Convert.ToString(rcrdsetUsers[1]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + Convert.ToString(rcrdsetUsers[2]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "</tr>";
            str.Append(ScriptDados);
        }
        ConexaoBancoSQL.fecharConexao();

        Literal2.Text = str.ToString();

    }
}