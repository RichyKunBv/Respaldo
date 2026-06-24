/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/GUIForms/JFrame.java to edit this template
 */

import java.awt.*;
import java.awt.event.*;
import java.util.ArrayList;
import javax.swing.*;
import javax.swing.Timer;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

/**
 *
 * @author rivenescamilla
 */
public class Main extends javax.swing.JFrame {
    
    // ---------- CONSTANTES GLOBALES (fáciles de modificar) ----------
    private static final String APP_VERSION = "1.0.0";
    private static final String APP_NAME = "Chafaint Base";
    private static final String APP_NM = "Proyecto Chafaint Base";
    private static final String APP_AUTHOR = "rescamilla";
    private static final String GIT_AUTHOR = "https://github.com/RichyKunBv";
    private static final String APP_GIT = "https://github.com/RichyKunBv/Chafaint";
    private static final String APP_ICON = "icon.png";   // cambia según tu icono
    private static final String APP_CN = "Base";

    // Nombres de los archivos de iconos para botones
    private static final String ICON_HELP = "?.png";
    private static final String ICON_CLEAR = "clear.png";
    private static final String ICON_COLOR = "color.png";
    private static final String ICON_EXIT = "exit.png";
    private static final String ICON_SIZE = "tamano.png";    
    
    // ---------- VARIABLES GLOBALES DE ESTADO ----------
    private Color currentColor = Color.BLACK;
    private int currentSize = 5;                     // grosor por defecto
    private int puntoSeleccionado = -1;               // índice en listaDibujables, -1 = ninguno
    private boolean arrastrando = false;
    private int indiceArrastre = -1;

    // Lista genérica de objetos dibujables (polimorfismo)
    private ArrayList<Dibujable> listaDibujables = new ArrayList<>();

    // Componentes de UI (algunos se necesitan como atributos para actualizarlos)
    private JLabel jTxtPositionX;
    private JLabel jTxtPositionY;
    private JLabel jLabelDay;
    private JLabel jLabelHour;
    private JLabel jLabelVersion;

    // Lienzo
    private LienzoPanel lienzo;

    // ToolBars (declaradas como en el diseñador, pero las inicializamos aquí)
    private JToolBar jToolBar1;
    private JToolBar jToolBar2;

    // ---------- INTERFAZ DIBUJABLE (para que cualquier figura pueda pintarse y ser seleccionada) ----------
    public interface Dibujable {
        void dibujar(Graphics2D g2);
        boolean contienePunto(int x, int y);   // para selección
        Color getColor();
        void setColor(Color c);
        int getGrosor();
        void setGrosor(int g);
    }

    // ---------- CLASE LIENZO ----------
    class LienzoPanel extends JPanel {
        public LienzoPanel() {
            setBackground(Color.WHITE);
            // Eventos de ratón (se pueden sobrescribir fácilmente)
            MouseAdapter mouseHandler = new MouseAdapter() {
                @Override
                public void mouseClicked(MouseEvent e) {
                    if (SwingUtilities.isLeftMouseButton(e) && e.getClickCount() == 1) {
                        onMouseClick(e);
                    }
                }

                @Override
                public void mousePressed(MouseEvent e) {
                    onMousePress(e);
                }

                @Override
                public void mouseDragged(MouseEvent e) {
                    onMouseDrag(e);
                }

                @Override
                public void mouseReleased(MouseEvent e) {
                    onMouseRelease(e);
                }

                @Override
                public void mouseMoved(MouseEvent e) {
                    actualizarCoordenadas(e);
                }
            };
            addMouseListener(mouseHandler);
            addMouseMotionListener(mouseHandler);
        }

        @Override
        protected void paintComponent(Graphics g) {
            super.paintComponent(g);
            Graphics2D g2 = (Graphics2D) g;
            g2.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);

            // Dibujar todas las figuras
            for (int i = 0; i < listaDibujables.size(); i++) {
                Dibujable d = listaDibujables.get(i);
                d.dibujar(g2);
                // Si está seleccionado, dibujar un borde o algo (opcional)
                if (i == puntoSeleccionado) {
                    // Por ejemplo, un rectángulo alrededor (cada figura debería gestionarlo, pero aquí podemos hacer algo genérico)
                }
            }
        }

        
        // Métodos de evento para que las subclases o el programador los sobrescriban fácilmente
        protected void onMouseClick(MouseEvent e) {
            // Por defecto: agregar un punto de prueba (se puede cambiar)
            listaDibujables.add(new Punto(e.getX(), e.getY(), currentColor, currentSize));
            repaint();
        }

        protected void onMousePress(MouseEvent e) {
            // Buscar si se hizo clic sobre una figura existente
            int idx = encontrarFiguraCercana(e.getX(), e.getY(), 10);
            if (idx != -1) {
                puntoSeleccionado = idx;
                indiceArrastre = idx;
                arrastrando = true;
                repaint();
            }
        }
        
        protected void onMouseDrag(MouseEvent e) {
            if (arrastrando && indiceArrastre != -1) {
                // Mover la figura (esto es genérico; la figura debería tener un método mover)
                // Como no todas las figuras son puntos, podemos definir un método mover en Dibujable
                Dibujable fig = listaDibujables.get(indiceArrastre);
                if (fig instanceof Punto) {
                    Punto p = (Punto) fig;
                    p.x = Math.max(0, Math.min(getWidth() - 1, e.getX()));
                    p.y = Math.max(0, Math.min(getHeight() - 1, e.getY()));
                }
                // Para otras figuras habría que implementar un método mover()
                repaint();
            }
        }
        
        protected void onMouseRelease(MouseEvent e) {
            arrastrando = false;
            indiceArrastre = -1;
        }
    }

    // ---------- CLASE PUNTO DE EJEMPLO (implementa Dibujable) ----------
    class Punto implements Dibujable {
        int x, y;
        Color color;
        int grosor;

        public Punto(int x, int y, Color color, int grosor) {
            this.x = x; this.y = y; this.color = color; this.grosor = grosor;
        }

        @Override
        public void dibujar(Graphics2D g2) {
            g2.setColor(color);
            g2.fillOval(x - grosor/2, y - grosor/2, grosor, grosor);
        }

        @Override
        public boolean contienePunto(int px, int py) {
            return Math.hypot(px - x, py - y) <= grosor/2 + 5;
        }

        @Override public Color getColor() { return color; }
        @Override public void setColor(Color c) { this.color = c; }
        @Override public int getGrosor() { return grosor; }
        @Override public void setGrosor(int g) { this.grosor = g; }
    }
    
    private static final java.util.logging.Logger logger = java.util.logging.Logger.getLogger(Main.class.getName());

    /**
     * Creates new form Main
     */
    public Main() {
        initUI();
        configurarVentana();
        iniciarReloj();
    }

    private void initUI() {
        jToolBar1 = new JToolBar();
        jToolBar2 = new JToolBar();
        jToolBar1.setFloatable(false);
        jToolBar2.setFloatable(false);

        // Botón Color
        JButton btnColor = crearBotonConIcono(ICON_COLOR, "Color", e -> ColorSelector());
        jToolBar1.add(btnColor);

        // Botón Grosor
        JButton btnSize = crearBotonConIcono(ICON_SIZE, "Grosor", e -> SizeSelector());
        jToolBar1.add(btnSize);

        // Botón Limpiar
        JButton btnClear = crearBotonConIcono(ICON_CLEAR, "Limpiar", e -> limpiarLienzo());
        jToolBar1.add(btnClear);

        // Botón Ayuda
        JButton btnHelp = crearBotonConIcono(ICON_HELP, "?", e -> mostrarAyuda());
        jToolBar1.add(btnHelp);

        // Botón Salir (opcional en la barra)
        JButton btnExit = crearBotonConIcono(ICON_EXIT, "Salir", e -> SALIR());
        jToolBar1.add(btnExit);

        // Etiquetas inferiores
        jLabelDay = new JLabel("Día: ");
        jLabelHour = new JLabel("Hora: ");
        jLabelVersion = new JLabel("Versión: " + APP_VERSION);
        jTxtPositionX = new JLabel("X: 0");
        jTxtPositionY = new JLabel("Y: 0");

        jToolBar2.add(jLabelDay);
        jToolBar2.add(jLabelHour);
        jToolBar2.addSeparator();
        jToolBar2.add(jLabelVersion);
        jToolBar2.addSeparator();
        jToolBar2.add(jTxtPositionX);
        jToolBar2.add(jTxtPositionY);

        // Menú
        JMenuBar menuBar = new JMenuBar();
        JMenu menuAyuda = new JMenu("Ayuda");
        JMenuItem itemAyuda = new JMenuItem("Ayuda");
        itemAyuda.addActionListener(e -> mostrarAyuda());
        JMenuItem itemAcerca = new JMenuItem("Acerca de");
        itemAcerca.addActionListener(e -> AcercaDE());
        JMenuItem itemHV = new JMenuItem("Historial de versiones");
        itemHV.addActionListener(e -> HV());
        JMenuItem itemSalir = new JMenuItem("Salir");
        itemSalir.addActionListener(e -> SALIR());

        menuAyuda.add(itemAyuda);
        menuAyuda.add(itemAcerca);
        menuAyuda.add(itemHV);
        menuAyuda.addSeparator();
        menuAyuda.add(itemSalir);
        menuBar.add(menuAyuda);
        setJMenuBar(menuBar);

        // Lienzo
        lienzo = new LienzoPanel();

        // Layout
        setLayout(new BorderLayout());
        add(jToolBar1, BorderLayout.NORTH);
        add(lienzo, BorderLayout.CENTER);
        add(jToolBar2, BorderLayout.SOUTH);
    }    
    
    /**
     * Crea un botón con icono si existe, si no, usa texto.
     */
    private JButton crearBotonConIcono(String iconName, String textoAlternativo, ActionListener accion) {
        JButton boton = new JButton();
        java.net.URL url = getClass().getResource("/chafaint/" + iconName);
        if (url == null) {
            url = getClass().getResource(iconName);
        }
        if (url != null) {
            boton.setIcon(new ImageIcon(url));
            boton.setToolTipText(textoAlternativo);
        } else {
            boton.setText(textoAlternativo);
        }
        boton.addActionListener(accion);
        boton.setFocusable(false);
        return boton;
    }    
    
    private void configurarVentana() {
        setTitle(APP_NAME);
        setSize(800, 600);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(DO_NOTHING_ON_CLOSE);
        addWindowListener(new WindowAdapter() {
            @Override
            public void windowClosing(WindowEvent e) {
                SALIR();
            }
        });
        
        // Icono
        try {
            java.net.URL urlIcono = getClass().getResource("/chafaint/" + APP_ICON);
            if (urlIcono == null) urlIcono = getClass().getResource(APP_ICON);
            if (urlIcono != null) {
                Image icono = new ImageIcon(urlIcono).getImage();
                setIconImage(icono);
                if (Taskbar.isTaskbarSupported()) {
                    Taskbar taskbar = Taskbar.getTaskbar();
                    if (taskbar.isSupported(Taskbar.Feature.ICON_IMAGE))
                        taskbar.setIconImage(icono);
                }
            }
        } catch (Exception e) {
            System.err.println("Icono no encontrado: " + APP_ICON);
        }
        
        // Tecla DELETE global
        KeyboardFocusManager.getCurrentKeyboardFocusManager().addKeyEventDispatcher(e -> {
            if (e.getID() == KeyEvent.KEY_PRESSED && e.getKeyCode() == KeyEvent.VK_DELETE) {
                borrarSeleccionado();
                return true;
            }
            return false;
        });
    }

    private void iniciarReloj() {
        new Timer(1000, e -> {
            LocalDateTime now = LocalDateTime.now();
            jLabelDay.setText("Día: " + now.toLocalDate());
            jLabelHour.setText("Hora: " + now.format(DateTimeFormatter.ofPattern("HH:mm:ss")));
        }).start();
    }
    
    
    
    // ---------- MÉTODOS LÓGICOS COMUNES ----------
    private void actualizarCoordenadas(MouseEvent e) {
        jTxtPositionX.setText("X: " + e.getX());
        jTxtPositionY.setText("Y: " + e.getY());
    }

    private int encontrarFiguraCercana(int x, int y, int radio) {
        for (int i = 0; i < listaDibujables.size(); i++) {
            if (listaDibujables.get(i).contienePunto(x, y))
                return i;
        }
        return -1;
    }

    private void borrarSeleccionado() {
        if (puntoSeleccionado != -1 && !listaDibujables.isEmpty()) {
            int confirm = JOptionPane.showConfirmDialog(this,
                "¿Borrar elemento seleccionado?", "Confirmar",
                JOptionPane.YES_NO_OPTION);
            if (confirm == JOptionPane.YES_OPTION) {
                listaDibujables.remove(puntoSeleccionado);
                puntoSeleccionado = -1;
                lienzo.repaint();
            }
        }
    }

    private void limpiarLienzo() {
        listaDibujables.clear();
        puntoSeleccionado = -1;
        lienzo.repaint();
    }

    private void ColorSelector() {
        Color c = JColorChooser.showDialog(this, "Color", currentColor);
        if (c != null) currentColor = c;
    }

    private void SizeSelector() {
        String s = JOptionPane.showInputDialog(this, "Grosor (1-50):", currentSize);
        if (s != null) {
            try {
                int nuevo = Integer.parseInt(s);
                if (nuevo >= 1 && nuevo <= 50) currentSize = nuevo;
                else JOptionPane.showMessageDialog(this, "El grosor debe estar entre 1 y 50.");
            } catch (NumberFormatException ex) {
                JOptionPane.showMessageDialog(this, "Número inválido.");
            }
        }
    }

    private void mostrarAyuda() {
        JOptionPane.showMessageDialog(this,
            APP_NM + " v" + APP_VERSION + "\n\n" +
            "Base moldeable para futuras versiones de Chafaint.\n" +
            "Haz clic para añadir puntos (ejemplo).\n" +
            "Selecciona un punto con clic y arrastra para moverlo.\n" +
            "Suprimir borra el seleccionado.\n" +
            "Personaliza los eventos en LienzoPanel.");
    }

    private void AcercaDE() {
        JOptionPane.showMessageDialog(this,
            APP_NM + "\nVersión: " + APP_VERSION +
            "\nAutor: " + APP_AUTHOR +
            "\nGit: " + GIT_AUTHOR +
            "\nProyecto: " + APP_GIT +
            "\nCodename: " + APP_CN);
    }

    private void HV() {
        JOptionPane.showMessageDialog(this,
            "Historial de versiones (base):\n" +
            "1.0.0 - Versión base con interfaz Dibujable, toolbars, reloj, métodos comunes.");
    }

    private void SALIR() {
        int op = JOptionPane.showConfirmDialog(this,
            "¿Salir de la aplicación?", "Salir",
            JOptionPane.YES_NO_OPTION);
        if (op == JOptionPane.YES_OPTION) {
            dispose();
            System.exit(0);
        }
    }
    
    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        addMouseMotionListener(new java.awt.event.MouseMotionAdapter() {
            public void mouseMoved(java.awt.event.MouseEvent evt) {
                formMouseMoved(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 400, Short.MAX_VALUE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 300, Short.MAX_VALUE)
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void formMouseMoved(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_formMouseMoved
        // TODO add your handling code here:
    }//GEN-LAST:event_formMouseMoved

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> new Main().setVisible(true));
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    // End of variables declaration//GEN-END:variables
}
