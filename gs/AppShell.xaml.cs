using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace gs
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        private Controls.HeaderView header;
        private readonly int heightBase = 250; // altura da minha header
        

        public AppShell()
        {
            InitializeComponent();
            header = new Controls.HeaderView();
            FlyoutHeaderBehavior = FlyoutHeaderBehavior.CollapseOnScroll; // Essa propriedade faz a mágica de aumentar e dimimuir a header
            header.HeightRequest = heightBase;
            FlyoutHeader = header;
            header.SizeChanged += Header_SizeChanged; //O Xamarin já altera o tamanho da header... eu só faço a captura desta alteração.
        }

        

        private void Header_SizeChanged(object sender, EventArgs e)
        {
            // NAO FACAM ALTERAcoes nas PROPRIEDADEs COMO WIDTH, ORIENTATION, elas travam o size changed
            // só é permitido usar scale, translationX e Y
            // não é um bug, existe uma lógica por não permitir usar esse tipo de propriedade

            var cont = 1 + (header.Height - 56); //contagem de 1 a 250, sendo 250 a altura final
            var hbase = heightBase - 56; //altura final, sendo 56 o tamanho da linha final

            //Usando regra de 3
            header.userImage.TranslationX = - ((header.Width / 2 - 50) - (cont * (header.Width/2 -50) / (hbase)));
            header.userImage.TranslationY = - (27 - (cont * 27 / hbase));
            header.userImage.Scale =  .4 + (cont * .6 / hbase);
            header.textStack.TranslationY = -(120 - (cont * 120 / hbase));
            header.textStack.Scale = .8 + (cont * .2 / hbase);

            //Usando regra de 3 e para fazer uma pequena curca nos textos, fica interessante para não ´bater´ na foto, eu uso antigos espiritos da matemática, neste caso o seno.
            double resTeam;
            double resUser;
            double waveQt = 3.1; // frequencia da onda
            double waveDist = 100; // largura da onda.

            double teamIni = header.Width / 2 - header.labelTeam.Width / 2; //posicao inicial, centraliza
            double teamEnd = 70; // posicao final, a 70 pixel de distancia, (espaco para a foto)
            double userIni = header.Width / 2 - header.labelUser.Width / 2; 
            double userEnd = 70;
          
            resTeam = teamEnd +  (cont * (teamIni - teamEnd) / hbase) ;
            resUser = userEnd + (cont * (userIni - userEnd) / hbase);
            var curva = resUser + (waveDist * Math.Sin((cont / hbase) * waveQt));
            // professora que dia que eu vou usar seno na minha vida ???... pois...
            var curvaTeam = resTeam + (waveDist * Math.Sin((cont / hbase) * waveQt));
            
            
            header.labelUser.TranslationX = curva;
            header.labelTeam.TranslationX = curvaTeam;

        }
    }
}