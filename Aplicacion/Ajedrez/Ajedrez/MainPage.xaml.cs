using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Windows.Input;
using Ajedrez.Resources;
using Ajedrez.Codigo.Modelo;


namespace Ajedrez
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
            // Código de ejemplo para traducir ApplicationBar
      
        }
        /// <summary>
        /// Sirve para guardar una brocha temporalmente
        /// </summary>
        Brush originalBrush;
        /// <summary>
        /// Representa el Ellipse que se ve involucrado en los eventos
        /// </summary>
        private Image currentEllipse = null;
        /// <summary>
        /// Representa el jugador que esta moviendo la pieza
        /// </summary>
        private Player currentPlayer = null;
        /// <summary>
        /// Determina de quien es el turno 
        /// </summary>
        private bool isPlayerOneTurn = true;
        /// <summary>
        /// Determina si el jugador que intenta mover, tiene permiso para hacerlo
        /// </summary>
        private bool canPlayerMove = false;

        /// <summary>
        /// Evento Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Se recorren todos los hijos que contiene el ContentPanel (que es un Grid en XAML)
            foreach (var item in ContentPanel.Children)
            {
                // Solo nos interesan los objetos tipo Ellipse
                if (item.GetType() == typeof(Image))
                {
                    // Obtenemos el Column y Row que tiene el Ellipse y se guarda en
                    // ShapesInBoard (que es un List<string>)
                    Image ellipse = item as Image;
                    int col = Convert.ToInt32(ellipse.GetValue(Grid.ColumnProperty));
                    int row = Convert.ToInt32(ellipse.GetValue(Grid.RowProperty));
                    var hardcodeString = String.Format("{0},{1}", col, row);
                    this.GameBoard.ShapesInBoard.Add(hardcodeString);
                }
            }
            // Se hace una copia exacta de las posiciones actuales de todas las piezas
            this.GameBoard.InitialPlaces.AddRange(this.GameBoard.ShapesInBoard);
        }

        /// <summary>
        /// Instancia que guarda las posiciones iniciales de las piezas y las posiciones con forme se van moviendo
        /// los Ellipses
        /// </summary>
        private Board GameBoard = new Board()
        {
            ShapesInBoard = new List<string>(),
            InitialPlaces = new List<string>()
        };

        /// <summary>
        /// Se ejecuta cuando inicia la manipulación de la pieza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image_ManipulationStarted_1(object sender, ManipulationStartedEventArgs e)
        {
            // Obtenemos la figura que se va a empezar a mover            
            this.currentEllipse = sender as Image;
            // Determinamos el jugador
            this.currentPlayer = Juego.GetMovingPlayer(this.currentEllipse);
            // Si es el jugador 1 y es su turno o si es el jugador 2 y no es el turno del jugador 1, canPlayerMove es true
            if (this.isPlayerOneTurn && this.currentPlayer.PlayerNumber == PlayerNum.PlayerOne || !this.isPlayerOneTurn && this.currentPlayer.PlayerNumber == PlayerNum.PlayerTwo)
            {
                canPlayerMove = true;
            }
            else
            {
                // Sino, el jugador no puede realizar ninguna transformación (osea, moverse)
                canPlayerMove = false;
                return;
            }
            // Un pequeño aumento de tamaño y cambio de color que se aprecia al momento de arrastrar la pieza
            CompositeTransform composite = this.currentEllipse.RenderTransform as CompositeTransform;
            composite.ScaleX = 1.3;
            composite.ScaleY = 1.3;
            // Se guarda el color original
            originalBrush = this.currentEllipse.Name;
            // Se cambia a un color mientras se arrastra
            this.currentEllipse.Name = new SolidColorBrush(Colors.Blue);
        }

        /// <summary>
        /// Evento que se ejecuta mientras se manipula el objeto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ellipse_ManipulationDelta_1(object sender, ManipulationDeltaEventArgs e)
        {
            // Si canPlayerMove es falso no puede moverse la pieza (osea no se le puede hacer ninguna transformación)
            if (!this.canPlayerMove)
                return;

            // Se hace una translación del Ellipse actual
            CompositeTransform composite = this.currentEllipse.RenderTransform as CompositeTransform;
            composite.TranslateX += e.DeltaManipulation.Translation.X;
            composite.TranslateY += e.DeltaManipulation.Translation.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ellipse_ManipulationCompleted_1(object sender, ManipulationCompletedEventArgs e)
        {
            // Si el jugador no puede hacer nada, no hacemos nada :)
            if (!this.canPlayerMove)
                return;

            // Determina si el movimiento fue valido
            bool isMoveSuccess = false;
            // Volvemos a la pieza al tamaño normal (porque la habíamos escalado)
            CompositeTransform composite = this.currentEllipse.RenderTransform as CompositeTransform;
            composite.ScaleX = 1;
            composite.ScaleY = 1;
            // Recuperamos su color original
            this.currentEllipse.Name = originalBrush;

            // Aquí viene la magia, la verdad es una implementación muy mala, pero funcionó!
            if (this.currentPlayer.PlayerNumber == PlayerNum.PlayerOne)
            {
                // El jugador 1 (el jugador de arriba), tiene ciertas restricciones, el no puede mover su ficha en negativo
                // es decir, la traslación que se le aplica debe de ser positiva, porque si es negativa, quiere decir que intentó
                // irse hacia atras (OJO, esto no aplica si quieren implementar las coronaciones de las fichas)
                // Por lo tanto, la ficha del jugador 1, en Y, su traslación no puede ser negativa, y aparte su traslación
                // no puede exeder los 70 pixeles, en mi GRID, cada cuadro mide 50 pixeles, le doy un overhead de 20 pixeles

                // Revisamos Y
                if (composite.TranslateY < 0 || composite.TranslateY > 70)
                {
                    // Si las traslaciónes no son validas, eliminamos la traslación y con el return; detenemos la ejecución de este evento
                    // en pocas palabras, regresa la pieza a su lugar original
                    composite.TranslateX = 0;
                    composite.TranslateY = 0;
                    return;
                }
                // El mismo caso es en el eje X
                // el eje X puede avanzar en positivo (derecha) o en negativo (izquierda), pero no debe de exceder más de dos cuadros, recuerden
                // que mis cuadros miden 50x50, por lo tanto yo le estoy dando un rango, la  traslación de la ficha, no debe de ser
                // mayor que 70 ni menor que 40 (porque tampoco, la ficha puede avanzar hacia adelante, sino en diagonal)

                // Revisamos X
                if ((composite.TranslateX < 70 && composite.TranslateX > 40) || (composite.TranslateX > -70 && composite.TranslateX < -40))
                {
                    // Con esto, sabemos si se movió a la izquierda o a la derecha
                    bool isNegative = composite.TranslateX < 0;

                    // Obtenemos la Columna y Fila actual (digamos 0,2)
                    var column = Convert.ToInt32(this.currentPlayer.Shape.GetValue(Grid.ColumnProperty));
                    var row = Convert.ToInt32(this.currentPlayer.Shape.GetValue(Grid.RowProperty));
                    // Creamos una cadena que tendrá  '0,2' para guardarla en nuestro List<string> de BoardGame
                    string originalPlace = String.Format("{0},{1}", column, row);
                    // Si se fue a la izquierda, se le resta una columna, si se fue a la derecha, se le agrega una columnma        
                    column = isNegative ? column - 1 : column + 1;
                    // Obligatorio res agregarle una fila (porque como es el jugador 1, tiene que avanzar hacia abajo)
                    row++;
                    // Esta será una cadena con la nueva posición que será '1,3'
                    string newPlace = String.Format("{0},{1}", column, row);

                    // Revisamos que no exista una pieza en ese lugar
                    var shapePlace = this.GameBoard.ShapesInBoard.Where(p => p.Equals(newPlace));

                    // Si no hay una pieza en ese lugar, se agrega la cadena newPlace al arreglo
                    // y se elimina originalPlace, aquí hacemos como que actualizamos su posición en el arreglo
                    if (shapePlace.Count() == 0)
                    {
                        this.GameBoard.ShapesInBoard.Remove(originalPlace);
                        this.GameBoard.ShapesInBoard.Add(newPlace);

                        // Las columnas de la figura actual ahora son diferentes porque les sumamos valores
                        this.currentPlayer.Shape.SetValue(Grid.ColumnProperty, column);
                        this.currentPlayer.Shape.SetValue(Grid.RowProperty, row);
                        // indicamos que fue un movimiento éxitoso
                        isMoveSuccess = true;
                    }

                }
                // Como hemos cambiado los valores de Grid.Column y Grid.Row ya no necesitamos las traslaciónes
                composite.TranslateX = 0;
                composite.TranslateY = 0;
            }
            else
            {
                // Lo mismo ocurre con el jugador 2, no es necesario explicarlo
                // Validamos la jugada del jugador 2
                // Revisamos Y
                if (composite.TranslateY > 0 || composite.TranslateY < -70)
                {
                    composite.TranslateX = 0;
                    composite.TranslateY = 0;
                    return;
                }
                // Revisamos X
                if ((composite.TranslateX < 70 && composite.TranslateX > 40) || (composite.TranslateX > -70 && composite.TranslateX < -40))
                {
                    bool isNegative = composite.TranslateX < 0;

                    var column = Convert.ToInt32(this.currentPlayer.Shape.GetValue(Grid.ColumnProperty));
                    var row = Convert.ToInt32(this.currentPlayer.Shape.GetValue(Grid.RowProperty));

                    string originalPlace = String.Format("{0},{1}", column, row);

                    column = isNegative ? column - 1 : column + 1;
                    row--;

                    string newPlace = String.Format("{0},{1}", column, row);

                    // Revisamos que no exista una pieza en ese lugar
                    var shapePlace = this.GameBoard.ShapesInBoard.Where(p => p.Equals(newPlace));


                    if (shapePlace.Count() == 0)
                    {
                        this.GameBoard.ShapesInBoard.Remove(originalPlace);
                        this.GameBoard.ShapesInBoard.Add(newPlace);

                        this.currentPlayer.Shape.SetValue(Grid.ColumnProperty, column);
                        this.currentPlayer.Shape.SetValue(Grid.RowProperty, row);
                        isMoveSuccess = true;
                    }

                }


                composite.TranslateX = 0;
                composite.TranslateY = 0;
            }

            // Si el movimiento fue éxitoso, es turno del otro jugador
            if (isMoveSuccess)
            {
                this.isPlayerOneTurn = this.currentPlayer.PlayerNumber == PlayerNum.PlayerOne ? false : true;
                txtInfo.Text = this.isPlayerOneTurn ? "Es el turno del Jugador 1" : "Es el turno del Jugador 2";
            }

        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            // reiniciamos todo
            int c = 0;
            foreach (var item in ContentPanel.Children)
            {
                if (item.GetType() == typeof(Image))
                {
                    Image ellipse = item as Image;
                    string[] dummyString = this.GameBoard.InitialPlaces[c].Split(',');
                    int oldCol = Convert.ToInt32(dummyString[0]);
                    int oldRow = Convert.ToInt32(dummyString[1]);

                    ellipse.SetValue(Grid.ColumnProperty, oldCol);
                    ellipse.SetValue(Grid.RowProperty, oldRow);

                    c++;
                }
            }

            this.isPlayerOneTurn = true;
            txtInfo.Text = "Es turno del Jugador 1";
            this.GameBoard.ShapesInBoard.Clear();
            this.GameBoard.ShapesInBoard.AddRange(this.GameBoard.InitialPlaces);
        }


    }
}