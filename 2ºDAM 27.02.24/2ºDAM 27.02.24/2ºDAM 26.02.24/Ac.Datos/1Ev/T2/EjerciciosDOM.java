import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.util.ArrayList;
import java.util.stream.Stream.Builder;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NamedNodeMap;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.w3c.dom.bootstrap.DOMImplementationRegistry;
import org.w3c.dom.ls.DOMImplementationLS;
import org.w3c.dom.ls.LSOutput;
import org.w3c.dom.ls.LSSerializer;

public class EjerciciosDOM {
    // Ejercicio 1

    public Document creaArbol(String ruta) {
        Document doc = null; // Document estructura DOM en memoria
        try {
            DocumentBuilderFactory factoria = DocumentBuilderFactory.newInstance();
            factoria.setIgnoringComments(true);
            DocumentBuilder db = factoria.newDocumentBuilder();
            doc = (Document) db.parse(ruta);

            System.out.println("Se ha copiado");

        } catch (Exception e) {
            System.out.println("Error al general el arbol dom" + e.getMessage());
        }
        return doc;

    }

    // Ejercicio 2. Hecho por Javi
    public void mostrarTitulos2(Document doc) {
        Node filmoteca, pelicula, nodoAux, atributo;
        filmoteca = doc.getFirstChild();
        NodeList peliculas, datos, titulos;

        titulos = doc.getElementsByTagName("titulo");
        for (int i = 0; i < titulos.getLength(); i++) {
            System.out.println(titulos.item(i).getFirstChild().getNodeValue());
        }

    }
    // 2
    // public void mostrarTitulos(Document doc){
    // Node filmoteca,pelicula,nodoAux,atributo;
    // filmoteca=doc.getFirstChild();
    // NodeList peliculas,datos;
    // NamedNodeMap atributos;
    // peliculas=filmoteca.getChildNodes();

    // for (int i = 0; i <((NodeList) peliculas).getLength(); i++) {
    // pelicula=peliculas.item(i);
    // if(pelicula.getNodeType()==Node.ELEMENT_NODE){
    // datos=pelicula.getChildNodes(); //titulo y director
    // //System.out.println("Título de la película: "+datos);
    // for (int j = 0; j < datos.getLength(); j++) {
    // nodoAux=datos.item(j); //titulo,director
    // //if(nodoAux.getNodeType()==Node.ELEMENT_NODE){
    // if(nodoAux.getNodeName().equals("titulo")){
    // //Como hago para que solo me muestre: título y el nombre?Así:
    // System.out.println(nodoAux.getNodeName()+"
    // "+nodoAux.getFirstChild().getNodeValue());

    // }
    // // }
    // }

    // }
    // }
    // }
    // Ejercicio 3
    public void mostrarDatos(Document doc) {
        // Director nombre, apellido y género, titulo pelicula
        Node raiz, pelicula, nodoAux, atributo, info;
        NodeList peliculas, datos, informacion;
        NamedNodeMap atributos;

        raiz = doc.getFirstChild();// FILMOTECA
        peliculas = raiz.getChildNodes();
        for (int i = 0; i < peliculas.getLength(); i++) {
            pelicula = peliculas.item(i);
            if (pelicula.hasAttributes()) {
                atributos = pelicula.getAttributes();
                
                atributo = atributos.item(1); // TODO no me coge el último atribut
                System.out.println(atributo.getNodeValue());
            }

            if (pelicula.getNodeType() == Node.ELEMENT_NODE) {
                datos = pelicula.getChildNodes(); // titulo y director
                // System.out.println("Título de la película: "+datos);
                for (int j = 0; j < datos.getLength(); j++) {
                    nodoAux = datos.item(j); // titulo,director
                    if (nodoAux.getNodeType() == Node.ELEMENT_NODE) {
                        if (nodoAux.getNodeName().equals("titulo")) {
                            System.out.println();
                            System.out.println("_____________________");
                            System.out.println();

                            // Como hago para que solo me muestre: título y el nombre?Así:
                            System.out.println(nodoAux.getNodeName() + " " + nodoAux.getFirstChild().getNodeValue());

                        }
                        if (nodoAux.getNodeName().equals("director")) {
                            informacion = nodoAux.getChildNodes();
                            for (int j2 = 0; j2 < informacion.getLength(); j2++) {
                                info = informacion.item(j2);
                                if (info.getNodeName().equals("nombre")) {

                                    System.out.println(info.getNodeName() + " " + info.getFirstChild().getNodeValue());
                                }
                                if (info.getNodeName().equals("apellido")) {

                                    System.out.println(info.getNodeName() + " " + info.getFirstChild().getNodeValue());
                                }
                            }
                        }
                    }
                }

            }
        }

    }

    // Ejercicio 4.
    public void recorrerRecursivo(Node nodo, int tabulador) {
        NodeList hijos = nodo.getChildNodes();
        for (int i = 0; i < hijos.getLength(); i++) {
            for (int j = 0; j <= tabulador; j++) {
                System.out.print("   ");

            }
            System.out.println(hijos.item(i).getNodeName() + " " + hijos.item(i).getNodeType());
            if (hijos.item(i).hasChildNodes()) {
                recorrerRecursivo(hijos.item(i), tabulador + 1);
            }
        }
    }

    
    // Ejercicio 5
    public void mostrarPeliculas(Document doc, int nDirectores) {

        NodeList peliculas, titulos, directores;

        peliculas = doc.getElementsByTagName("pelicula");
        for (int i = 0; i < peliculas.getLength(); i++) {
            Element peli = (Element) peliculas.item(i);
            directores = peli.getElementsByTagName("director");
            titulos = peli.getElementsByTagName("titulo");
            if (directores.getLength() >= nDirectores) { // compruebo que tenga más de nDirect y luego cojo el títulos
                if (titulos.getLength() > 0) {
                    System.out.println(titulos.item(0).getFirstChild().getNodeValue());
                    // El indice 0 de títulos, es el primer título que cojo
                    // Por qué cojo getFirstChild??
                }
            }

        }

    }

    // Ejercicio 6
    public void generosPeliculas(Document d) {
        ArrayList<String> gns = new ArrayList<>();
        NodeList generos, peliculas;

        peliculas = d.getElementsByTagName("pelicula");

        for (int i = 0; i < peliculas.getLength(); i++) {
            Element pelicula = (Element) peliculas.item(i);
            if (pelicula.hasAttribute("genero")) {
                if (!gns.contains(pelicula.getAttribute("genero"))) {
                    gns.add(pelicula.getAttribute("genero"));

                }

            }
        }
        for (int j = 0; j < gns.size(); j++) {
            System.out.println(gns.get(j));

        }
    }

    // Ejercicio 7
    public void addAtributo(Document d, String titulo, String atributo, String valor) {
        NodeList titulos;
        Node titu;
        Element pelicula;
        // getFirstChild().getNodeValue()---> para coger el valor de un elemento
        try {
            titulos = d.getElementsByTagName(titulo);

            for (int i = 0; i < titulos.getLength(); i++) {
                if (titulos.item(i).getFirstChild().getNodeValue().equals(titulo)) {
                    pelicula = (Element) titulos.item(i).getParentNode();

                    if (!pelicula.hasAttribute(atributo)) {
                        pelicula.setAttribute(atributo, valor);
                    }
                }

            }

        } catch (Exception e) {
e.printStackTrace();
        }
    }

    // Ejercicio 7b
    public void eliminarAtributo(Document d, String titulo, String atributo) {
        NodeList titulos;
        Node titu;
        Element pelicula;
        // getFirstChild().getNodeValue()---> para coger el valor de un elemento,lo que
        // está entre los corchetes
        try {
            titulos = d.getElementsByTagName(titulo);

            for (int i = 0; i < titulos.getLength(); i++) {
                if (titulos.item(i).getFirstChild().getNodeValue().equals(titulo)) {
                    pelicula = (Element) titulos.item(i).getParentNode();

                    if (pelicula.hasAttribute(atributo)) {
                        pelicula.removeAttribute(atributo);
                        ;
                    }
                }

            }

        } catch (Exception e) {

        }
    }

    // Ejercicio 8
    public void añadirPeli(Document d, String nombredire, String apellidodire, String titulo) {
        NodeList titulos;
        Node titu, director;
        Element pelicula, nombre, apellido;
        // creo los nodos en el documento, y se los añado a las etiquetas con appends
        // getFirstChild().getNodeValue()---> para coger el valor de un elemento,lo que
        // está entre los corchetes
        try {
            pelicula = (Element) d.createElement("pelicula");
            pelicula.setAttribute("año", "1987");
            // pelicula.appendChild(d.createTextNode(titulo));

            // TODO corregir titulo, no se me muestra
            titu = d.createElement("titulo");
            titu.appendChild(d.createTextNode(titulo));
            pelicula.appendChild(titu);

            Node director2 = d.createElement("director");
            director = pelicula.appendChild(director2);

            Node nombre2 = d.createElement("nombre");
            nombre2.appendChild(d.createTextNode(nombredire));
            director.appendChild(nombre2);
            Node apellido2 = d.createElement("apellido");
            apellido2.appendChild(d.createTextNode(apellidodire));
            director.appendChild(apellido2);
            // director2.appendChild(d.createTextNode("pepe"));
            // pelicula.appendChild("director");
            d.getFirstChild().appendChild(pelicula);

        } catch (Exception e) {

        }
    }

    
    // Ejercicio 9
    public void cambiarNombre(Document d, String nombre, String nombreReplace, String apellido) {
        NodeList listaNombres, hijosDirector;
        Node nodo;
        Element elemento;
        try {
            listaNombres = d.getElementsByTagName("nombre");
            for (int i = 0; i < listaNombres.getLength(); i++) {
                if (listaNombres.item(i).getFirstChild().getNodeValue().equals(nombre)) {

                    System.out.println(listaNombres.item(i).getFirstChild().getNodeValue());
                    hijosDirector = listaNombres.item(i).getParentNode().getChildNodes();
                    for (int j = 0; j < hijosDirector.getLength(); j++) {
                        if (hijosDirector.item(j).getNodeName().equals("apellido")) {
                            if (hijosDirector.item(j).getFirstChild().getNodeValue().equals(apellido)) {
                                listaNombres.item(i).getFirstChild().setNodeValue(nombreReplace);
                            }
                        }
                    }
                }

            }
            grabarDOM(d, "CambiarNombre.txt");
        } catch (Exception e) {

        }
    }
    // Ejercicio 10
    public void añadirDirector(Document d, String albert, String apellido){
        NodeList listaNombres, hijosDirector;
        Node nodo;
        Element elemento;
        try {
            listaNombres = d.getElementsByTagName("titulo");
             for (int i = 0; i < listaNombres.getLength(); i++) {
                if (listaNombres.item(i).getFirstChild().getNodeValue().equals("Dune")) {
            
                    Element director =  d.createElement("director");
                    Element nombre =  d.createElement("nombre");
                    Element apellido1 =  d.createElement("apellido");

                    nombre.appendChild(d.createTextNode(albert));
                    apellido1.appendChild(d.createTextNode(apellido));

                        
                    director.appendChild(nombre);
                    director.appendChild(apellido1);


                    listaNombres.item(i).getParentNode().appendChild(director);

                    
                
                   
                }
            }
            
        }catch(Exception e){

        }
    }


    public void grabarDOM(Document document, String ficheroSalida)
            throws ClassNotFoundException, InstantiationException,
            IllegalAccessException, FileNotFoundException {
        DOMImplementationRegistry registry = DOMImplementationRegistry.newInstance();
        DOMImplementationLS ls = (DOMImplementationLS) registry.getDOMImplementation("XML 3.0 LS 3.0");
        // Se crea un destino vacio
        LSOutput output = ls.createLSOutput();
        output.setEncoding("UTF-8");
        // Se establece el flujo de salida
        output.setByteStream(new FileOutputStream(ficheroSalida));
        // output.setByteStream(System.out);
        // Permite escribir un documento DOM en XML
        LSSerializer serializer = ls.createLSSerializer();
        // Se establecen las propiedades del serializador
        serializer.setNewLine("\r\n");
        ;
        serializer.getDomConfig().setParameter("format-pretty-print", true);
        // Se escribe el documento ya sea en un fichero o en una cadena de texto
        serializer.write(document, output);
        // String xmlCad=serializer.writeToString(document);
    }
}
