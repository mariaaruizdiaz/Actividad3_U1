using Geolocation;

class Viaje {
    private Coordinate origen;
    private Coordinate destino;
    private DateTime fecha;

    public Viaje() { }

    //Metodos  SET
    public void setOrigen(double latitud, double longitud) {
        origen = new Coordinate(latitud, longitud);
    }

    public void setDestino(double latitud, double longitud){
        destino = new Coordinate(latitud, longitud);
    }

    public void setFecha(DateTime fecha) {
        this.fecha = fecha; 
    }

    //Metodos GET
    public Coordinate getOrigen() {
        return origen;
    }

    public Coordinate getDestino()
    {
        return destino;
    }

    public DateTime getFecha() {
        return fecha;
    }

    public double calcularDistancia() {
        double distancia = GeoCalculator.GetDistance(origen, destino, 1);
        distancia = distancia / 0.621371;
        System.Console.WriteLine("\tLa distancia es {0:N2} kilometros.", distancia);
        return distancia;
    }

    public double calcularTiempoEstimado(double distancia) {
        // d = v*t;  t = d/v;
        double tiempo = (distancia/50) * 60;
        System.Console.WriteLine("\tTiempo estimado: {0:N2} minutos.", tiempo);
        return tiempo;
    }

    public void calcularHoraLlegada(double tiempo) {
        DateTime horaLlegada = fecha.AddMinutes(tiempo);
        System.Console.WriteLine("\tHora de llegada estimada: {0}.", horaLlegada);
    }

    public double calcularCosto(double distancia) {
        // 50 pesos x cada 2 kilometros
        double costo = distancia * 25;
        System.Console.WriteLine("\tCosto estimado: {0:N2} pesos.", costo);
        return costo;
    }

    public string calcularDireccion() {
        string direccion = GeoCalculator.GetDirection(origen, destino);
        System.Console.WriteLine("\tDireccion cardinal: {0}", direccion);
        return direccion;
    }
}

class Test {
    public static void Main(string []args) {
        Viaje miViaje = new Viaje();
        double latitudO, longitudO, latitudD, longitudD, distancia, tiempo;
        //DateTime ejemplo de fecha("10/22/2015 12:10:15 PM");  
        DateTime fecha = DateTime.Now;
        miViaje.setFecha(fecha);

        System.Console.WriteLine(">> Bienvenido a Viajes Ubar <<");

        System.Console.WriteLine(">> Coordenadas ORIGEN de tu viaje <<)");
        System.Console.WriteLine(">> Latitud: ");
        latitudO = Convert.ToDouble(Console.ReadLine());
        System.Console.WriteLine(">> Longitud: ");
        longitudO = Convert.ToDouble(Console.ReadLine());
        //miViaje.setOrigen(latitudO, longitudO);
        miViaje.setOrigen(34.0675918, -118.3977091);

        System.Console.WriteLine(">> Coordenadas DESTINO de tu viaje <<)");
        System.Console.WriteLine(">> Latitud: ");
        latitudD = Convert.ToDouble(Console.ReadLine());
        System.Console.WriteLine(">> Longitud: ");
        longitudD = Convert.ToDouble(Console.ReadLine());
        //miViaje.setDestino(latitudD, longitudD);
        miViaje.setDestino(34.076234, -118.395314);

        System.Console.WriteLine("\n>>----------------------DETALLES DEL VIAJE -----------------<<");
        distancia = miViaje.calcularDistancia();
        miViaje.calcularDireccion();
        miViaje.calcularCosto(distancia);
        tiempo = miViaje.calcularTiempoEstimado(distancia);
        miViaje.calcularHoraLlegada(tiempo);
        System.Console.WriteLine("\n>>----------------------------------------------------------<<");
    }
}