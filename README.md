# Tasa BCV

Este es un servicio de Windows que realiza scraping de la página del Banco Central de Venezuela (BCV) para obtener las tasas de cambio de varias divisas, incluyendo el Euro, Yuan, Lira, Rublo y Dólar. Los valores obtenidos se muestran en la bandeja del sistema y se actualizan cada hora.

## Características

- **Scraping de tasas de cambio**: Extrae datos de la página oficial del BCV.
- **Notificaciones en la bandeja del sistema**: Muestra las tasas de cambio y el título de la fecha actual.
- **Interacción del usuario**: Permite verificar las tasas de cambio mediante un clic derecho en el icono de la bandeja del sistema.
- **Opción de salir y configuración para iniciar con el sistema**.

## Tecnologías utilizadas

- C# .NET
- HtmlAgilityPack
- Windows Forms

## Requisitos

- .NET Framework 4.5 o superior.
- Acceso a internet para obtener las tasas de cambio.

## Instalación

1. Clona este repositorio en tu máquina local:
   ```bash
   git clone https://github.com/jgjimenez/tasabcv
