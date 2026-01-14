#include <iostream>
#include <string>
#include <cctype>

enum ResultadoValidacion
{
    NUMERO_VALIDO,
    FORMATO_INVALIDO,
    MIXTO
};

class ValidadorCadena
{
public:
    ResultadoValidacion analizar(std::string entrada)
    {
        if (entrada.length() == 0)
        {
            return FORMATO_INVALIDO;
        }

        for (int i = 0; i < entrada.length(); i++)
        {
            char caracter = entrada[i];
            if (!isdigit(caracter) && caracter != '.' && caracter != '-')
            {
                return MIXTO;
            }
        }

        int contador_puntos = 0;
        int contador_guiones = 0;

        for (int i = 0; i < entrada.length(); i++)
        {
            if (entrada[i] == '.')
            {
                contador_puntos++;
            }
            if (entrada[i] == '-')
            {
                contador_guiones++;
            }
        }

        if (contador_puntos > 1 || contador_guiones > 1)
        {
            return FORMATO_INVALIDO;
        }

        if (contador_guiones == 1 && entrada[0] != '-')
        {
            return FORMATO_INVALIDO;
        }

        if (entrada == "." || entrada == "-")
        {
            return FORMATO_INVALIDO;
        }

        if (entrada.length() > 1 && entrada[0] == '0' && entrada[1] != '.')
        {
            return FORMATO_INVALIDO;
        }
        if (entrada.length() > 2 && entrada[0] == '-' && entrada[1] == '0' && entrada[2] != '.')
        {
            return FORMATO_INVALIDO;
        }

        return NUMERO_VALIDO;
    }
};

int main()
{
    ValidadorCadena miValidador;
    std::string entradaUsuario;

    std::cout << "--- Validacion de Numeros ---" << std::endl;
    std::cout << "Escribe un numero para validar (o 'salir' para salir (para que mas escribirias salir?))." << std::endl;

    while (true)
    {
        std::cout << "\n> ";
        std::getline(std::cin, entradaUsuario);

        if (entradaUsuario == "salir") //toca hacer un lujito como poner salir para salir 🗿
        {
            break;
        }

        ResultadoValidacion resultado = miValidador.analizar(entradaUsuario);

        std::cout << "Resultado: ";
        switch (resultado)
        {
        case NUMERO_VALIDO:
            std::cout << "✅  (Felicidades ya te puedes graduar UwU)" << std::endl;
            break;
        case FORMATO_INVALIDO:
            std::cout << "❌  (Regresa a primaria, asi no se escriben los numeros)" << std::endl;
            break;
        case MIXTO:
            std::cout << "🚫  (Regresa a kinder ese no es un numero)" << std::endl;
            break;
        }
    }

    std::cout << "¡Hasta luego!" << std::endl;
    return 0;
}