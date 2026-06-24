/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/GUIForms/JFrame.java to edit this template
 */
package escalainador;

import java.awt.*;
import java.awt.image.BufferedImage;
import java.io.File;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import javax.imageio.ImageIO;
import javax.swing.*;
import java.awt.image.VolatileImage;


/**
 *
 * @author rescamilla
 */
public class Main extends javax.swing.JFrame {
    
    private static final java.util.logging.Logger logger = java.util.logging.Logger.getLogger(Main.class.getName());

    // Constantes de la aplicación
    private static final String APP_VERSION = "0.5.1";
    private static final String APP_AUTHOR = "rescamilla";
    private static final String GIT_AUTHOR = "https://github.com/RichyKunBv";
    private static final String APP_GIT = "https://github.com/RichyKunBv/Escalainador";
    private static final String APP_ICON = "ayane.jpg"; 
    private static final String APP_NAME = "EscalaInador Super Full HD 4K LG TV+ HDR UHD Retina Pro";
    private static final String APP_NM = "EscalaInador";
    private static final String APP_CN = "Ayane";

    // Componentes adicionales
    private ImagePanel imagePanel;   // Panel personalizado que dibuja la imagen ajustada al tamaño
    private BufferedImage originalImage;
    private final double[] scalFactors = {0.05, 0.25, 0.5, 0.75, 1.0, 2.0, 3.0, 4.0, 5.0};
    private final VolatileImage[] scaledImages = new VolatileImage[scalFactors.length];
    private JPanel rightPanel;      
    private JPanel buttonPanel;  
    
    /**
     * Creates new form Main
     */
    public Main() {
        initComponents();

        // Configuración inicial
        setTitle(APP_NAME);
        configurarIcono();
        configurarSlider();
        configurarAreaImagen();
        configurarBotonesFactores();
        configurarReloj();

        // Asignar acciones a los menús
        jMenuOpen.addActionListener(e -> abrirImagen());
        jMenuExit.addActionListener(e -> salir());
        jMenuHelp.addActionListener(e -> mostrarAyuda());
        jMenuAD.addActionListener(e -> acercaDe());
        jMenuHV.addActionListener(e -> historialVersiones());
        jMenuExport.addActionListener(e -> exportarImagen());

        jToolBar1.setFloatable(false);
        jLabelVersion.setText("Versión: " + APP_VERSION);
        
        jLabelAcel.setText("Aceleración: " + detectarPipelineActivo());

    }

    
    private String detectarPipelineActivo() {
    GraphicsConfiguration gc = GraphicsEnvironment
        .getLocalGraphicsEnvironment()
        .getDefaultScreenDevice()
        .getDefaultConfiguration();
    
    String className = gc.getClass().getName();
    
    if (className.contains("OGL"))    return "OpenGL";
    if (className.contains("D3D"))    return "Direct3D";
    if (className.contains("MTL"))    return "Metal";
    if (className.contains("XRender") || className.contains("XR")) return "XRender";
    return "Software (Java2D) [" + className + "]";
}
    
    
    private void configurarIcono() {
        try {
            java.net.URL urlIcono = getClass().getResource("/escalainador/" + APP_ICON);
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
    }
    
        private void configurarSlider() {
        jSliderZoom.setMinimum(0);
        jSliderZoom.setMaximum(8);
        jSliderZoom.setValue(4);
        jSliderZoom.setMajorTickSpacing(1);
        jSliderZoom.setSnapToTicks(true);
        jSliderZoom.setPaintTicks(true);
        jSliderZoom.setPaintLabels(true);

        java.util.Hashtable<Integer, JLabel> labelTable = new java.util.Hashtable<>();
        labelTable.put(8, new JLabel("5x"));
        labelTable.put(7, new JLabel("4x"));
        labelTable.put(6, new JLabel("3x"));
        labelTable.put(5, new JLabel("2x"));
        labelTable.put(4, new JLabel("1x"));
        labelTable.put(3, new JLabel("0.75"));
        labelTable.put(2, new JLabel("0.5"));
        labelTable.put(1, new JLabel("0.25"));
        labelTable.put(0, new JLabel("0.05"));
        jSliderZoom.setLabelTable(labelTable);

jSliderZoom.addChangeListener(e -> {
    if (!jSliderZoom.getValueIsAdjusting()) {
        actualizarImagenDesdeCache();
    }
});
    }

    private void configurarBotonesFactores() {
        buttonPanel = new JPanel(new GridLayout(scalFactors.length, 1, 2, 2));
        buttonPanel.setBorder(BorderFactory.createTitledBorder("Factores"));

        for (int i = scalFactors.length - 1; i >= 0; i--) {
            double factor = scalFactors[i];
            String texto;
            if (factor >= 1) {
                texto = (int) factor + "x";
            } else {
                texto = String.valueOf(factor).replace(".", ",") + "x";
            }
            JButton btn = new JButton(texto);
            final int pos = i;
            btn.addActionListener(e -> jSliderZoom.setValue(pos));
            buttonPanel.add(btn);
        }

        Container contentPane = getContentPane();
        contentPane.remove(jSliderZoom);

        // Crear panel derecho con BorderLayout
        rightPanel = new JPanel(new BorderLayout(5, 5));
        rightPanel.add(jSliderZoom, BorderLayout.WEST);
        rightPanel.add(buttonPanel, BorderLayout.CENTER);
        rightPanel.setPreferredSize(new Dimension(160, 0));

        // Volver a agregar los componentes en el orden correcto
        GroupLayout layout = (GroupLayout) contentPane.getLayout();
        layout.setHorizontalGroup(
            layout.createParallelGroup(GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addComponent(jScrollPane1, GroupLayout.DEFAULT_SIZE, 550, Short.MAX_VALUE)
                .addPreferredGap(LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(rightPanel, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE))
            .addComponent(jToolBar1, GroupLayout.DEFAULT_SIZE, GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING)
                    .addComponent(jScrollPane1, GroupLayout.DEFAULT_SIZE, 291, Short.MAX_VALUE)
                    .addComponent(rightPanel, GroupLayout.DEFAULT_SIZE, GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                .addPreferredGap(LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(jToolBar1, GroupLayout.PREFERRED_SIZE, 25, GroupLayout.PREFERRED_SIZE))
        );
        contentPane.validate();
    }

    private void configurarAreaImagen() {
        imagePanel = new ImagePanel();
        imagePanel.setBackground(Color.DARK_GRAY);
        jScrollPane1.setViewportView(imagePanel);
    }

    private void configurarReloj() {
        if (jLabelDate == null) {
            jLabelDate = new JLabel("Día: ");
            jToolBar1.add(jLabelDate, 0);
        }
        Timer timer = new Timer(1000, e -> {
            LocalDateTime now = LocalDateTime.now();
            jLabelDate.setText("Día: " + now.toLocalDate());
            jLabelHour.setText("Hora: " + now.format(DateTimeFormatter.ofPattern("HH:mm:ss")));
        });
        timer.start();
    }

    
    private void abrirImagen() {
    JFileChooser fileChooser = new JFileChooser();
    fileChooser.setFileFilter(new javax.swing.filechooser.FileNameExtensionFilter("Imágenes JPG", "jpg", "jpeg"));
    int result = fileChooser.showOpenDialog(this);
    if (result == JFileChooser.APPROVE_OPTION) {
        File file = fileChooser.getSelectedFile();
        try {
            // Limpiar cache ANTES de precargar
            for (int i = 0; i < scaledImages.length; i++) {
                scaledImages[i] = null;
            }
            originalImage = ImageIO.read(file);
            precargarEscalados();
            actualizarImagenDesdeCache();
        } catch (Exception ex) {
            JOptionPane.showMessageDialog(this, "Error al cargar la imagen:\n" + ex.getMessage());
        }
    }
}

    private void precargarEscalados() {
        if (originalImage == null) return;
        for (int i = 0; i < scalFactors.length; i++) {
            double factor = scalFactors[i];
            int newWidth = (int) (originalImage.getWidth() * factor);
            int newHeight = (int) (originalImage.getHeight() * factor);
            if (newWidth < 1) newWidth = 1;
            if (newHeight < 1) newHeight = 1;
            scaledImages[i] = escalarConCalidad(originalImage, newWidth, newHeight);
        }
    }

    
    private VolatileImage escalarConCalidad(BufferedImage src, int width, int height) {

    GraphicsConfiguration gc =
        GraphicsEnvironment.getLocalGraphicsEnvironment()
        .getDefaultScreenDevice()
        .getDefaultConfiguration();

VolatileImage img = gc.createCompatibleVolatileImage(width, height, Transparency.TRANSLUCENT);

    do {
        int valid = img.validate(gc);

        if (valid == VolatileImage.IMAGE_INCOMPATIBLE) {
            img = gc.createCompatibleVolatileImage(width, height);
        }

        Graphics2D g = img.createGraphics();

        g.setRenderingHint(RenderingHints.KEY_INTERPOLATION,
                RenderingHints.VALUE_INTERPOLATION_NEAREST_NEIGHBOR);

        g.drawImage(src, 0, 0, width, height, null);

        g.dispose();

    } while (img.contentsLost());

    return img;
}



    private void actualizarImagenDesdeCache() {
        if (originalImage == null) return;
        int pos = jSliderZoom.getValue();
        if (pos >= 0 && pos < scaledImages.length && scaledImages[pos] != null) {
            imagePanel.setImage(scaledImages[pos]);
        }
    }
    
    private void exportarImagen() {
    if (originalImage == null || scaledImages[jSliderZoom.getValue()] == null) {
        JOptionPane.showMessageDialog(this, "No hay imagen cargada.");
        return;
    }

    JFileChooser fileChooser = new JFileChooser();
    fileChooser.setSelectedFile(new File("imagen_escalada.svg"));
    fileChooser.setFileFilter(new javax.swing.filechooser.FileNameExtensionFilter("SVG", "svg"));
    int result = fileChooser.showSaveDialog(this);

    if (result == JFileChooser.APPROVE_OPTION) {
        File file = fileChooser.getSelectedFile();
        if (!file.getName().toLowerCase().endsWith(".svg")) {
            file = new File(file.getAbsolutePath() + ".svg");
        }

        try {
            // Convertir VolatileImage a BufferedImage
            Image img = scaledImages[jSliderZoom.getValue()];
            int w = img.getWidth(null);
            int h = img.getHeight(null);
            BufferedImage bi = new BufferedImage(w, h, BufferedImage.TYPE_INT_RGB);
            Graphics g = bi.createGraphics();
            g.drawImage(img, 0, 0, null);
            g.dispose();

            // Convertir BufferedImage a base64 PNG
            java.io.ByteArrayOutputStream baos = new java.io.ByteArrayOutputStream();
            ImageIO.write(bi, "png", baos);
            String base64 = java.util.Base64.getEncoder().encodeToString(baos.toByteArray());

            // Escribir SVG con imagen embebida
            String svg = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
                "<svg xmlns=\"http://www.w3.org/2000/svg\" " +
                    "xmlns:xlink=\"http://www.w3.org/1999/xlink\" " +
                    "width=\"" + w + "\" height=\"" + h + "\">\n" +
                "  <image width=\"" + w + "\" height=\"" + h + "\" " +
                    "xlink:href=\"data:image/png;base64," + base64 + "\"/>\n" +
                "</svg>";

            java.nio.file.Files.writeString(file.toPath(), svg);
            JOptionPane.showMessageDialog(this, "SVG guardado en: " + file.getAbsolutePath());

        } catch (Exception ex) {
            JOptionPane.showMessageDialog(this, "Error al exportar SVG: " + ex.getMessage());
        }
    }
}

    private void mostrarAyuda() {
        JOptionPane.showMessageDialog(this,
                APP_NM + " v" + APP_VERSION + "\n\n" +
                "INSTRUCCIONES DE USO:\n" +
                "1. Abrir una imagen JPG con Archivo > Abrir.\n" +
                "2. Usar el slider vertical o los botones numéricos para cambiar la resolución.\n" +
                "3. La imagen siempre se ajusta al tamaño del panel.\n" +
                "4. Para salir, Archivo > Salir.\n\n" +
                "Rendimiento mejorado con precarga y aceleración gráfica.");
    }

    private void salir() {
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

    private void acercaDe() {
        JOptionPane.showMessageDialog(this,
                APP_NM + "\n" +
                "Versión: " + APP_VERSION + "\n" +
                "Desarrollado por: " + APP_AUTHOR + "\n" +
                "Git del desarrollador: " + GIT_AUTHOR + "\n" +
                "Git del proyecto: " + APP_GIT + "\n" +
                "Codename: " + APP_CN + "\n" +
                "Aceleración (cuchau): OpenGL (Windows/Linux/macOS), Direct3D (Windows), XRender (Linux)");
    }

    private void historialVersiones() {
        JOptionPane.showMessageDialog(this,
                APP_NM + " v" + APP_VERSION + "\n" +
                "Git del proyecto: " + APP_GIT + "\n" +
                "Codename: " + APP_CN + "\n" +
                "0.1.0: Versión inicial con zoom y slider\n" +
                "0.2.0: Ahora hay imagenes y una monita china de logo yupi\n" +
                "0.3.0: La aplicacion no era como la hice y tuve que volverla a hacer XD\n" +
                "0.4.0: La imagen siempre esta del mismo tamaño no se hace chica ni grande\n" +
                "0.5.0: Ahora hay aceleracion por Hardware (mi pc no puede con su vida minimo ahora funciona este pedo)\n" +
                "0.5.1: En la barra de abajo puedes ver cual tipo de aceleracion estas usando");
    }

// Panel personalizado que dibuja la imagen escalada al tamaño del panel
private class ImagePanel extends JPanel {
    private Image image;

    public void setImage(Image image) {
        this.image = image;
        revalidate();
        repaint();
    }

    @Override
public Dimension getPreferredSize() {
    return new Dimension(
        jScrollPane1.getViewport().getWidth(),
        jScrollPane1.getViewport().getHeight()
    );
}

    @Override
protected void paintComponent(Graphics g) {
    super.paintComponent(g);
    if (image == null) return;

    Graphics2D g2 = (Graphics2D) g;

    int panelW = getWidth();
    int panelH = getHeight();
    int imgW = image.getWidth(null);
    int imgH = image.getHeight(null);

    // Calcular escala manteniendo proporción
    double scaleX = (double) panelW / imgW;
    double scaleY = (double) panelH / imgH;
    double scale = Math.min(scaleX, scaleY); // usa el menor para no deformar

    int drawW = (int) (imgW * scale);
    int drawH = (int) (imgH * scale);

    // Centrar en el panel
    int x = (panelW - drawW) / 2;
    int y = (panelH - drawH) / 2;

    g2.setRenderingHint(RenderingHints.KEY_INTERPOLATION,
            RenderingHints.VALUE_INTERPOLATION_BILINEAR);
    g2.drawImage(image, x, y, drawW, drawH, null);
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

        jSliderZoom = new javax.swing.JSlider();
        jScrollPane1 = new javax.swing.JScrollPane();
        jToolBar1 = new javax.swing.JToolBar();
        jLabelDate = new javax.swing.JLabel();
        jSeparator5 = new javax.swing.JToolBar.Separator();
        jLabel1 = new javax.swing.JLabel();
        jSeparator6 = new javax.swing.JToolBar.Separator();
        jLabelHour = new javax.swing.JLabel();
        jSeparator3 = new javax.swing.JToolBar.Separator();
        jLabelVersion = new javax.swing.JLabel();
        jSeparator4 = new javax.swing.JToolBar.Separator();
        jLabelAcel = new javax.swing.JLabel();
        jSliderScal = new javax.swing.JSlider();
        jMenuBar1 = new javax.swing.JMenuBar();
        jMenu1 = new javax.swing.JMenu();
        jMenuOpen = new javax.swing.JMenuItem();
        jMenuExport = new javax.swing.JMenuItem();
        jSeparator1 = new javax.swing.JPopupMenu.Separator();
        jMenuExit = new javax.swing.JMenuItem();
        jMenu2 = new javax.swing.JMenu();
        jMenuAD = new javax.swing.JMenuItem();
        jMenuHelp = new javax.swing.JMenuItem();
        jSeparator2 = new javax.swing.JPopupMenu.Separator();
        jMenuHV = new javax.swing.JMenuItem();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        jSliderZoom.setBackground(new java.awt.Color(255, 153, 153));
        jSliderZoom.setForeground(new java.awt.Color(204, 204, 255));
        jSliderZoom.setOrientation(javax.swing.JSlider.VERTICAL);

        jToolBar1.setBackground(new java.awt.Color(255, 102, 102));
        jToolBar1.setRollover(true);

        jLabelDate.setText("Fecha: ");
        jToolBar1.add(jLabelDate);
        jToolBar1.add(jSeparator5);

        jLabel1.setText("ÙwÚ");
        jToolBar1.add(jLabel1);
        jToolBar1.add(jSeparator6);

        jLabelHour.setText(" Hora:  ");
        jToolBar1.add(jLabelHour);
        jToolBar1.add(jSeparator3);

        jLabelVersion.setText("Version: ");
        jToolBar1.add(jLabelVersion);
        jToolBar1.add(jSeparator4);

        jLabelAcel.setText("Aceleracion con:");
        jToolBar1.add(jLabelAcel);

        jSliderScal.setBackground(new java.awt.Color(255, 153, 153));
        jSliderScal.setForeground(new java.awt.Color(204, 204, 255));
        jSliderScal.setOrientation(javax.swing.JSlider.VERTICAL);

        jMenuBar1.setBackground(new java.awt.Color(255, 153, 153));
        jMenuBar1.setForeground(new java.awt.Color(0, 0, 0));

        jMenu1.setText("Archivo");

        jMenuOpen.setIcon(new javax.swing.ImageIcon(getClass().getResource("/escalainador/document-open.png"))); // NOI18N
        jMenuOpen.setText("Abrir");
        jMenu1.add(jMenuOpen);

        jMenuExport.setText("Exportar a SVG");
        jMenuExport.addActionListener(this::jMenuExportActionPerformed);
        jMenu1.add(jMenuExport);
        jMenu1.add(jSeparator1);

        jMenuExit.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_Q, java.awt.event.InputEvent.CTRL_DOWN_MASK));
        jMenuExit.setIcon(new javax.swing.ImageIcon(getClass().getResource("/escalainador/exit.png"))); // NOI18N
        jMenuExit.setText("Salir");
        jMenu1.add(jMenuExit);

        jMenuBar1.add(jMenu1);

        jMenu2.setText("Ayuda");

        jMenuAD.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_F12, java.awt.event.InputEvent.CTRL_DOWN_MASK));
        jMenuAD.setText("Acerca De");
        jMenu2.add(jMenuAD);

        jMenuHelp.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_F1, java.awt.event.InputEvent.CTRL_DOWN_MASK));
        jMenuHelp.setText("Ayuda");
        jMenu2.add(jMenuHelp);
        jMenu2.add(jSeparator2);

        jMenuHV.setText("Historial de Versiones");
        jMenu2.add(jMenuHV);

        jMenuBar1.add(jMenu2);

        setJMenuBar(jMenuBar1);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addComponent(jSliderZoom, javax.swing.GroupLayout.PREFERRED_SIZE, 50, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(jScrollPane1)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(jSliderScal, javax.swing.GroupLayout.PREFERRED_SIZE, 50, javax.swing.GroupLayout.PREFERRED_SIZE))
            .addComponent(jToolBar1, javax.swing.GroupLayout.DEFAULT_SIZE, 630, Short.MAX_VALUE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jSliderScal, javax.swing.GroupLayout.DEFAULT_SIZE, 385, Short.MAX_VALUE)
                    .addComponent(jSliderZoom, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(jScrollPane1))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(jToolBar1, javax.swing.GroupLayout.PREFERRED_SIZE, 25, javax.swing.GroupLayout.PREFERRED_SIZE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void jMenuExportActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuExportActionPerformed
            exportarImagen();
    }//GEN-LAST:event_jMenuExportActionPerformed

    /**
     * @param args the command line arguments
     */
public static void main(String args[]) {
    String os = System.getProperty("os.name").toLowerCase();

    // Forzar aceleración antes de que arranque AWT
    System.setProperty("sun.java2d.accthreshold", "0"); // acelerar desde pixel 0
    System.setProperty("sun.java2d.translaccel", "true"); // aceleración translúcida

    if (os.contains("win")) {
        System.setProperty("sun.java2d.d3d", "true");
        System.setProperty("sun.java2d.d3d.onscreen", "true");
        System.setProperty("sun.java2d.opengl", "true");
    }

    if (os.contains("linux")) {
        System.setProperty("sun.java2d.opengl", "true");
        System.setProperty("sun.java2d.opengl.fbobject", "true"); // FBO para mejor perf
        System.setProperty("sun.java2d.xrender", "true");
    }

    if (os.contains("mac")) {
        // Metal es el pipeline nativo en macOS moderno, no necesita forzarse
        // OpenGL está deprecated en mac, mejor dejarlo al JDK
        System.setProperty("apple.awt.graphics.UseQuartz", "true");
    }

    java.awt.EventQueue.invokeLater(() -> new Main().setVisible(true));
}


    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabelAcel;
    private javax.swing.JLabel jLabelDate;
    private javax.swing.JLabel jLabelHour;
    private javax.swing.JLabel jLabelVersion;
    private javax.swing.JMenu jMenu1;
    private javax.swing.JMenu jMenu2;
    private javax.swing.JMenuItem jMenuAD;
    private javax.swing.JMenuBar jMenuBar1;
    private javax.swing.JMenuItem jMenuExit;
    private javax.swing.JMenuItem jMenuExport;
    private javax.swing.JMenuItem jMenuHV;
    private javax.swing.JMenuItem jMenuHelp;
    private javax.swing.JMenuItem jMenuOpen;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JPopupMenu.Separator jSeparator1;
    private javax.swing.JPopupMenu.Separator jSeparator2;
    private javax.swing.JToolBar.Separator jSeparator3;
    private javax.swing.JToolBar.Separator jSeparator4;
    private javax.swing.JToolBar.Separator jSeparator5;
    private javax.swing.JToolBar.Separator jSeparator6;
    private javax.swing.JSlider jSliderScal;
    private javax.swing.JSlider jSliderZoom;
    private javax.swing.JToolBar jToolBar1;
    // End of variables declaration//GEN-END:variables
}
