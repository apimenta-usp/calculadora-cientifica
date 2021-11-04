using System.Drawing;
using System.Windows.Forms;

namespace InterfaceUsuario.Personalizacao {
    public class ControleDeImagens {
        public static void UmaImagem(Button botao, Bitmap imagem) {
            botao.BackColor = Color.Transparent;
            botao.BackgroundImage = imagem;
            botao.BackgroundImageLayout = ImageLayout.Zoom;
            botao.ForeColor = Color.Transparent;
        }

        public static void DuasImagens(Button botao, Bitmap imagemBotao,
                            PictureBox pictureBox, Bitmap imagemPictureBox) {
            botao.BackColor = Color.Transparent;
            botao.BackgroundImage = imagemBotao;
            botao.BackgroundImageLayout = ImageLayout.Zoom;
            botao.ForeColor = Color.Transparent;

            pictureBox.BackColor = Color.Transparent;
            pictureBox.BackgroundImage = imagemPictureBox;
            pictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox.ForeColor = Color.Transparent;
        }
    }
}
