namespace Perimetrorectangulo2429805
{
    public partial class MainPage : ContentPage
    {
        int _editRectanguloId = 0;
        private readonly LocalDbService _dbService = new LocalDbService();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            double baseRectangulo, alturaRectangulo;

            if (double.TryParse(baseEntryField.Text, out baseRectangulo) && double.TryParse(alturaEntryField.Text, out alturaRectangulo))
            {
                if (_editRectanguloId == 0)
                {
                    await _dbService.Create(new Rectangulo
                    {
                        Base = baseRectangulo,
                        Altura = alturaRectangulo
                    });
                }
                else
                {
                    await _dbService.Update(new Rectangulo
                    {
                        Id = _editRectanguloId,
                        Base = baseRectangulo,
                        Altura = alturaRectangulo
                    });
                    _editRectanguloId = 0;
                }

                baseEntryField.Text = string.Empty;
                alturaEntryField.Text = string.Empty;

                ListView.ItemsSource = await _dbService.GetRectangulos();
            }
            else
            {
                await DisplayAlert("Error", "Por favor ingresa valores válidos para la base y la altura.", "OK");
            }
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var rectangulo = (Rectangulo)e.Item;
            var action = await DisplayActionSheet("Acción", "Cancelar", null, "Editar", "Eliminar");
            switch (action)
            {
                case "Editar":
                    _editRectanguloId = rectangulo.Id;
                    baseEntryField.Text = rectangulo.Base.ToString();
                    alturaEntryField.Text = rectangulo.Altura.ToString();
                    break;

                case "Eliminar":
                    await _dbService.Delete(rectangulo);
                    ListView.ItemsSource = await _dbService.GetRectangulos();
                    break;
            }
        }
    }


}
