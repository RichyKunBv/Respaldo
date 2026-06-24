/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/GUIForms/JFrame.java to edit this template
 */
package chafaint;

import java.util.ArrayList; 
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Color;
import java.awt.BasicStroke;
import java.awt.BorderLayout;
import javax.swing.JPanel;
import javax.swing.JOptionPane;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import javax.swing.Timer;
import java.awt.KeyboardFocusManager;
import java.awt.event.KeyEvent;

/**
 *
 * @author rescamilla
 */
public class Main extends javax.swing.JFrame {
    // --- VARIABLES GLOBALES ---
    private ArrayList<Nodo> listaPuntos = new ArrayList<>();
    private Color currentColor = Color.BLACK;
    private int currentSize = 10;
    private static final int MAX_PUNTOS = 2; // Máximo 2 puntos
    private static final String APP_VERSION = "0.4.0";
    private static final String APP_AUTHOR = "rescamilla"; 
    private static final String GIT_AUTHOR = "https://github.com/RichyKunBv";
    private static final String APP_GIT = "NO HAY";
    private static final String APP_ICON = "luka.jpg";
    private static final String APP_NAME = "Chafaint Premium Delux Super Papu Pro Edition Rotador";
    private static final String APP_NM = "Proyecto Chafaint 3";
    private static final String APP_CN = "Luka";


    private LienzoPanel lienzo;
    
    // Variables para selección y modificación
    private int puntoSeleccionado = -1; // -1 significa ninguno seleccionado
    private boolean arrastrandoPunto = false;
    private int puntoArrastrando = -1;

    // Variables manuales (Por seguridad)
    private javax.swing.JLabel jTxtPositionX;
    private javax.swing.JLabel jTxtPositionY;
    private javax.swing.JLabel jTxtColorCode;
    
    class LienzoPanel extends JPanel {
        public LienzoPanel() {
            this.setBackground(Color.WHITE);
        }
        
        @Override
        protected void paintComponent(Graphics g) {
            super.paintComponent(g); 
            Graphics2D g2 = (Graphics2D) g;
            g2.setRenderingHint(java.awt.RenderingHints.KEY_ANTIALIASING, java.awt.RenderingHints.VALUE_ANTIALIAS_ON);

            if (!listaPuntos.isEmpty()) {
                // Dibujar puntos
                for (int i = 0; i < listaPuntos.size(); i++) {
                    Nodo actual = listaPuntos.get(i);
                    
                    if (i == puntoSeleccionado) {
                        g2.setColor(Color.RED);
                        g2.fillOval(actual.x - 5, actual.y - 5, 10, 10);
                    } else {
                        g2.setColor(actual.color);
                        g2.fillOval(actual.x - 3, actual.y - 3, 6, 6);
                    }
                }
                
                // Si hay exactamente 2 puntos, dibujar la línea entre ellos
                if (listaPuntos.size() == 2) {
                    Nodo p1 = listaPuntos.get(0);
                    Nodo p2 = listaPuntos.get(1);
                    // Usamos el grosor y color del primer punto (podría ser el promedio, pero así es simple)
                    g2.setStroke(new BasicStroke(p1.grosor));
                    g2.setColor(p1.color);
                    g2.drawLine(p1.x, p1.y, p2.x, p2.y);
                }
            }
        }
    }

    // CLASE NODO
    class Nodo {
        int x, y; Color color; int grosor;
        public Nodo(int x, int y, Color color, int grosor) {
            this.x = x; this.y = y; this.color = color; this.grosor = grosor;
        }
    }
    
    // Logger
    private static final java.util.logging.Logger logger = java.util.logging.Logger.getLogger(Main.class.getName());
    
    /**
     * Creates new form Main
     */
    public Main() {
        initComponents();

        setTitle(APP_NAME);

        try {
java.net.URL urlIcono = getClass().getResource("/chafaint/" + APP_ICON);
            if (urlIcono == null) {
                urlIcono = getClass().getResource(APP_ICON);
            }
            if (urlIcono != null) {
                java.awt.Image icono = new javax.swing.ImageIcon(urlIcono).getImage();
                setIconImage(icono);
                if (java.awt.Taskbar.isTaskbarSupported()) {
                    java.awt.Taskbar taskbar = java.awt.Taskbar.getTaskbar();
                    if (taskbar.isSupported(java.awt.Taskbar.Feature.ICON_IMAGE)) {
                        taskbar.setIconImage(icono);
                    }
                }
            } else {
System.err.println("¡No se encontró " + APP_ICON + "!");
            }
        } catch (Exception e) {
            e.printStackTrace();
        }

        jToolBar1.setFloatable(false);
        jToolBar2.setFloatable(false);

        
        jLabelVersion.setText("Versión: " + APP_VERSION);    

        
        // --- RELOJ ---
        Timer timer = new Timer(1000, e -> {
            LocalDateTime now = LocalDateTime.now();
            if(jLabelDay != null) jLabelDay.setText("Día: " + now.toLocalDate());
            if(jLabelHour != null) jLabelHour.setText("Hora: " + now.format(DateTimeFormatter.ofPattern("HH:mm:ss")));
        });
        timer.start();

        // --- LIENZO ---
        getContentPane().setLayout(new BorderLayout());
        getContentPane().add(jToolBar1, BorderLayout.NORTH);
        getContentPane().add(jToolBar2, BorderLayout.SOUTH);

        lienzo = new LienzoPanel();
        getContentPane().add(lienzo, BorderLayout.CENTER);

        // Eventos del Mouse
        javax.swing.event.MouseInputAdapter mouseHandler = new javax.swing.event.MouseInputAdapter() {
            @Override
            public void mousePressed(java.awt.event.MouseEvent evt) {
                if (javax.swing.SwingUtilities.isLeftMouseButton(evt)) {
                    // Verificar si se hizo clic sobre un punto existente
                    int puntoClicado = encontrarPuntoCercano(evt.getX(), evt.getY(), 10);
                    if (puntoClicado != -1) {
                        // Seleccionar punto y preparar arrastre
                        puntoSeleccionado = puntoClicado;
                        puntoArrastrando = puntoClicado;
                        arrastrandoPunto = true;
                        lienzo.repaint();
                    } else {
                        // Si no hay punto cerca, agregar nuevo punto solo si no se ha alcanzado el máximo
                        if (listaPuntos.size() < MAX_PUNTOS) {
                            listaPuntos.add(new Nodo(evt.getX(), evt.getY(), currentColor, currentSize));
                            // Si ahora tenemos 2 puntos, automáticamente se dibuja la línea
                            puntoSeleccionado = -1; // Deseleccionar cualquier punto anterior
                            lienzo.repaint();
                        } else {
                            // Opcional: notificar al usuario que ya hay 2 puntos
                            // JOptionPane.showMessageDialog(Main.this, "Ya has dibujado el máximo de 2 puntos.");
                        }
                    }
                }
            }

            @Override
            public void mouseDragged(java.awt.event.MouseEvent evt) {
                if (arrastrandoPunto && puntoArrastrando != -1) {
                    Nodo punto = listaPuntos.get(puntoArrastrando);
                    punto.x = Math.max(0, Math.min(lienzo.getWidth() - 1, evt.getX()));
                    punto.y = Math.max(0, Math.min(lienzo.getHeight() - 1, evt.getY()));
                    lienzo.repaint();
                }
            }

            @Override
            public void mouseReleased(java.awt.event.MouseEvent evt) {
                if (arrastrandoPunto) {
                    Nodo punto = listaPuntos.get(puntoArrastrando);
                    punto.x = Math.max(0, Math.min(lienzo.getWidth() - 1, punto.x));
                    punto.y = Math.max(0, Math.min(lienzo.getHeight() - 1, punto.y));
                    arrastrandoPunto = false;
                    puntoArrastrando = -1;
                    lienzo.repaint();
                }
            }
        };

        lienzo.addMouseListener(mouseHandler);
        lienzo.addMouseMotionListener(mouseHandler);

        // Tecla DELETE global
        KeyboardFocusManager.getCurrentKeyboardFocusManager().addKeyEventDispatcher(e -> {
            if (e.getID() == KeyEvent.KEY_PRESSED && e.getKeyCode() == KeyEvent.VK_DELETE) {
                borrarPuntoSeleccionado();
                return true;
            }
            return false;
        });

        addWindowListener(new java.awt.event.WindowAdapter() {
            @Override
            public void windowClosing(java.awt.event.WindowEvent e) {
                SALIR();
            }
        });

        setSize(800, 600);
        setLocationRelativeTo(null);
    }


    // --- MÉTODOS DE LÓGICA (EL CEREBRO) ---


    private int encontrarPuntoCercano(int x, int y, int radio) {
        for (int i = 0; i < listaPuntos.size(); i++) {
            Nodo p = listaPuntos.get(i);
            double dist = Math.sqrt(Math.pow(x - p.x, 2) + Math.pow(y - p.y, 2));
            if (dist <= radio) {
                return i;
            }
        }
        return -1;
    }

    private void limpiarLienzo() { 
        listaPuntos.clear(); 
        puntoSeleccionado = -1;
        lienzo.repaint();
    }

    private void ColorSelector() {
        Color c = javax.swing.JColorChooser.showDialog(this, "Color", currentColor);
        if(c != null) currentColor = c;
    }

    private void SizeSelector() {
        String s = JOptionPane.showInputDialog(this, "Grosor (1-50):", currentSize);
        if (s != null) {
            try {
                int nuevo = Integer.parseInt(s);
                if (nuevo >= 1 && nuevo <= 50) {
                    currentSize = nuevo;
                } else {
                    JOptionPane.showMessageDialog(this, "El grosor debe estar entre 1 y 50.");
                }
            } catch (NumberFormatException e) {
                JOptionPane.showMessageDialog(this, "Debe ingresar un número entero.");
            }
        }
    }

    private void mostrarAyuda() {
        JOptionPane.showMessageDialog(this, 
            APP_NM + " v" + APP_VERSION + "\n\n" +
            "INSTRUCCIONES DE USO:\n" +
            "- Click izquierdo en espacio vacío: Agrega un punto (máximo 2 puntos).\n" +
            "- Click izquierdo sobre un punto existente: Lo selecciona (rojo).\n" +
            "- Arrastrar un punto seleccionado: Lo mueve en tiempo real.\n" +
            "- Tecla DELETE: Borra el punto seleccionado.\n" +
            "- Botón 'Color': Cambia el color de los nuevos puntos.\n" +
            "- Botón 'Grosor': Cambia el grosor de la línea.\n" +
            "- Botón 'Limpiar Pantalla': Elimina todos los puntos.\n" +
            "- Menú Archivo > Salir: Cierra la aplicación.\n\n" +
            "Consejo: Con dos puntos se dibuja automáticamente una línea.");
    }

    private void SALIR() {
        int confirmarSalida = JOptionPane.showConfirmDialog(this,
            "¿Está seguro que desea salir de la aplicación?",
            "Salir",
            JOptionPane.YES_NO_OPTION,
            JOptionPane.QUESTION_MESSAGE);

        if (confirmarSalida == JOptionPane.YES_OPTION) {
            this.dispose();
            System.exit(0);
        }
    }

    private void AcercaDE() {                                        
        JOptionPane.showMessageDialog(this, 
            APP_NM + "\n" +
            "Versión: " + APP_VERSION + "\n" +
            "Desarrollado por: " + APP_AUTHOR + "\n" +
            "Git del desarrollador: " + GIT_AUTHOR +"\n" +
            "Git del proyecto " + APP_GIT + "\n" +
            "Codename: " + APP_CN);
    }

    private void borrarPuntoSeleccionado() {
        if (puntoSeleccionado != -1 && !listaPuntos.isEmpty()) {
            int confirm = JOptionPane.showConfirmDialog(this, 
                "¿Borrar punto " + (puntoSeleccionado + 1) + "?", 
                "Borrar Punto", 
                JOptionPane.YES_NO_OPTION);
            if (confirm == JOptionPane.YES_OPTION) {
                listaPuntos.remove(puntoSeleccionado);
                puntoSeleccionado = -1;
                lienzo.repaint();
            }
        } else {
            JOptionPane.showMessageDialog(this, "No hay punto seleccionado para borrar.");
        }
    }

    private void HV() {
        JOptionPane.showMessageDialog(this, 
            APP_NM + " v" + APP_VERSION + "\n" +
            "Git del proyecto " + APP_GIT + "\n" +
            "Codename: " + APP_CN + "\n" +
            "0.1: Creacion del proyecto\n" +
            "0.2: Simplificación: selección con un clic, arrastre directo, sin menú contextual\n" +
            "0.3: Límite a 2 puntos, solo una línea\n" +
            "0.4: Organizacion del codigo y agregacion del Codename");
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jToolBar1 = new javax.swing.JToolBar();
        jSeparator4 = new javax.swing.JToolBar.Separator();
        jButtonColor = new javax.swing.JButton();
        jSeparator5 = new javax.swing.JToolBar.Separator();
        jButtonSize = new javax.swing.JButton();
        jSeparator6 = new javax.swing.JToolBar.Separator();
        jButtonClear = new javax.swing.JButton();
        jSeparator7 = new javax.swing.JToolBar.Separator();
        jButtonHelp = new javax.swing.JButton();
        jToolBar2 = new javax.swing.JToolBar();
        jLabelDay = new javax.swing.JLabel();
        jLabelHour = new javax.swing.JLabel();
        jSeparator10 = new javax.swing.JToolBar.Separator();
        jLabelVersion = new javax.swing.JLabel();
        jMenuBar1 = new javax.swing.JMenuBar();
        jMenu1 = new javax.swing.JMenu();
        jMenuExit = new javax.swing.JMenuItem();
        jMenu3 = new javax.swing.JMenu();
        jMenuHelp = new javax.swing.JMenuItem();
        jMenuAD = new javax.swing.JMenuItem();
        jSeparator11 = new javax.swing.JPopupMenu.Separator();
        jMenuHV = new javax.swing.JMenuItem();

        setDefaultCloseOperation(javax.swing.WindowConstants.DO_NOTHING_ON_CLOSE);
        setTitle("Chafaint Premium Delux Super Papu Pro Edition");
        setCursor(new java.awt.Cursor(java.awt.Cursor.CROSSHAIR_CURSOR));
        setPreferredSize(new java.awt.Dimension(600, 400));

        jToolBar1.setBackground(new java.awt.Color(255, 204, 204));
        jToolBar1.setForeground(new java.awt.Color(255, 204, 204));
        jToolBar1.setRollover(true);
        jToolBar1.add(jSeparator4);

        jButtonColor.setIcon(new javax.swing.ImageIcon(getClass().getResource("/chafaint/cute-pencil-cartoon-by-Vexels (1).png"))); // NOI18N
        jButtonColor.setToolTipText("Color");
        jButtonColor.setFocusable(false);
        jButtonColor.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
        jButtonColor.setVerticalTextPosition(javax.swing.SwingConstants.BOTTOM);
        jButtonColor.addActionListener(this::jButtonColorActionPerformed);
        jToolBar1.add(jButtonColor);
        jToolBar1.add(jSeparator5);

        jButtonSize.setIcon(new javax.swing.ImageIcon(getClass().getResource("/chafaint/tamano.png"))); // NOI18N
        jButtonSize.setToolTipText("Size");
        jButtonSize.setFocusable(false);
        jButtonSize.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
        jButtonSize.setVerticalTextPosition(javax.swing.SwingConstants.BOTTOM);
        jButtonSize.addActionListener(this::jButtonSizeActionPerformed);
        jToolBar1.add(jButtonSize);
        jToolBar1.add(jSeparator6);

        jButtonClear.setText("Limpiar Pantalla");
        jButtonClear.setFocusable(false);
        jButtonClear.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
        jButtonClear.setVerticalTextPosition(javax.swing.SwingConstants.BOTTOM);
        jButtonClear.addActionListener(this::jButtonClearActionPerformed);
        jToolBar1.add(jButtonClear);
        jToolBar1.add(jSeparator7);

        jButtonHelp.setText("?");
        jButtonHelp.setFocusable(false);
        jButtonHelp.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
        jButtonHelp.setVerticalTextPosition(javax.swing.SwingConstants.BOTTOM);
        jButtonHelp.addActionListener(this::jButtonHelpActionPerformed);
        jToolBar1.add(jButtonHelp);

        jToolBar2.setBackground(new java.awt.Color(255, 204, 204));
        jToolBar2.setForeground(new java.awt.Color(255, 204, 204));
        jToolBar2.setRollover(true);

        jLabelDay.setText("Dia: ");
        jToolBar2.add(jLabelDay);

        jLabelHour.setText("Hora:");
        jToolBar2.add(jLabelHour);
        jToolBar2.add(jSeparator10);

        jLabelVersion.setText("Version: ");
        jToolBar2.add(jLabelVersion);

        jMenu1.setText("Archivo");

        jMenuExit.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_Q, java.awt.event.InputEvent.CTRL_DOWN_MASK));
        jMenuExit.setIcon(new javax.swing.ImageIcon(getClass().getResource("/chafaint/exit.png"))); // NOI18N
        jMenuExit.setText("Salir");
        jMenuExit.addActionListener(this::jMenuExitActionPerformed);
        jMenu1.add(jMenuExit);

        jMenuBar1.add(jMenu1);

        jMenu3.setText("Ayuda");

        jMenuHelp.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_F1, java.awt.event.InputEvent.CTRL_DOWN_MASK));
        jMenuHelp.setText("?");
        jMenuHelp.addActionListener(this::jMenuHelpActionPerformed);
        jMenu3.add(jMenuHelp);

        jMenuAD.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_F12, java.awt.event.InputEvent.CTRL_DOWN_MASK));
        jMenuAD.setText("Acerca De");
        jMenuAD.addActionListener(this::jMenuADActionPerformed);
        jMenu3.add(jMenuAD);
        jMenu3.add(jSeparator11);

        jMenuHV.setText("Historial de Versiones");
        jMenuHV.addActionListener(this::jMenuHVActionPerformed);
        jMenu3.add(jMenuHV);

        jMenuBar1.add(jMenu3);

        setJMenuBar(jMenuBar1);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(jToolBar1, javax.swing.GroupLayout.DEFAULT_SIZE, 583, Short.MAX_VALUE)
            .addComponent(jToolBar2, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addComponent(jToolBar1, javax.swing.GroupLayout.PREFERRED_SIZE, 25, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 353, Short.MAX_VALUE)
                .addComponent(jToolBar2, javax.swing.GroupLayout.PREFERRED_SIZE, 25, javax.swing.GroupLayout.PREFERRED_SIZE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void jMenuHelpActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuHelpActionPerformed
        mostrarAyuda();
    }//GEN-LAST:event_jMenuHelpActionPerformed

    private void jMenuADActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuADActionPerformed
        AcercaDE();
    }//GEN-LAST:event_jMenuADActionPerformed

    private void jButtonColorActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButtonColorActionPerformed
        ColorSelector();
    }//GEN-LAST:event_jButtonColorActionPerformed

    private void jButtonClearActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButtonClearActionPerformed
        limpiarLienzo();
    }//GEN-LAST:event_jButtonClearActionPerformed

    private void jButtonHelpActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButtonHelpActionPerformed
        mostrarAyuda();
    }//GEN-LAST:event_jButtonHelpActionPerformed

    private void jMenuHVActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuHVActionPerformed
        HV();
    }//GEN-LAST:event_jMenuHVActionPerformed

    private void jMenuExitActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuExitActionPerformed
        SALIR();
    }//GEN-LAST:event_jMenuExitActionPerformed

    private void jButtonSizeActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButtonSizeActionPerformed
        SizeSelector();
    }//GEN-LAST:event_jButtonSizeActionPerformed

    /**
     * @param args the command line arguments
     */
public static void main(String args[]) {
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException | InstantiationException | IllegalAccessException | javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(Main.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(() -> new Main().setVisible(true));
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton jButtonClear;
    private javax.swing.JButton jButtonColor;
    private javax.swing.JButton jButtonHelp;
    private javax.swing.JButton jButtonSize;
    private javax.swing.JLabel jLabelDay;
    private javax.swing.JLabel jLabelHour;
    private javax.swing.JLabel jLabelVersion;
    private javax.swing.JMenu jMenu1;
    private javax.swing.JMenu jMenu3;
    private javax.swing.JMenuItem jMenuAD;
    private javax.swing.JMenuBar jMenuBar1;
    private javax.swing.JMenuItem jMenuExit;
    private javax.swing.JMenuItem jMenuHV;
    private javax.swing.JMenuItem jMenuHelp;
    private javax.swing.JToolBar.Separator jSeparator10;
    private javax.swing.JPopupMenu.Separator jSeparator11;
    private javax.swing.JToolBar.Separator jSeparator4;
    private javax.swing.JToolBar.Separator jSeparator5;
    private javax.swing.JToolBar.Separator jSeparator6;
    private javax.swing.JToolBar.Separator jSeparator7;
    private javax.swing.JToolBar jToolBar1;
    private javax.swing.JToolBar jToolBar2;
    // End of variables declaration//GEN-END:variables

    
    
}
