namespace CG_Exp2_FillGraphicPrimitive
{
    partial class mainFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_drawArea = new System.Windows.Forms.Panel();
            this.textBox_LineX0 = new System.Windows.Forms.TextBox();
            this.button_startDraw = new System.Windows.Forms.Button();
            this.textBox_LineY0 = new System.Windows.Forms.TextBox();
            this.textBox_LineXn = new System.Windows.Forms.TextBox();
            this.textBox_LineYn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_chooseColor = new System.Windows.Forms.Button();
            this.textBox_bucketX = new System.Windows.Forms.TextBox();
            this.textBox_bucketY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_bucket4 = new System.Windows.Forms.Button();
            this.button_bucket8 = new System.Windows.Forms.Button();
            this.button_clearCanvas = new System.Windows.Forms.Button();
            this.button_output = new System.Windows.Forms.Button();
            this.button_bucketScan = new System.Windows.Forms.Button();
            this.textBox_clickY = new System.Windows.Forms.TextBox();
            this.textBox_clickX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_setClickStart = new System.Windows.Forms.Button();
            this.button_setClickEnd = new System.Windows.Forms.Button();
            this.button_setClickFill = new System.Windows.Forms.Button();
            this.button_chooseImage = new System.Windows.Forms.Button();
            this.button_imageFill = new System.Windows.Forms.Button();
            this.button_createLayer = new System.Windows.Forms.Button();
            this.listBox_layers = new System.Windows.Forms.ListBox();
            this.textBox_selectedLayer = new System.Windows.Forms.TextBox();
            this.button_deleteLayer = new System.Windows.Forms.Button();
            this.button_layerUp = new System.Windows.Forms.Button();
            this.button_layerDown = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button_drawSelection = new System.Windows.Forms.Button();
            this.button_getSelection = new System.Windows.Forms.Button();
            this.button_showSelection = new System.Windows.Forms.Button();
            this.button_fillSelection = new System.Windows.Forms.Button();
            this.button_clearSelection = new System.Windows.Forms.Button();
            this.button_hideLayer = new System.Windows.Forms.Button();
            this.textBox_circleCenterX = new System.Windows.Forms.TextBox();
            this.textBox_circleCenterY = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_setClickCenter = new System.Windows.Forms.Button();
            this.textBox_circleRadius = new System.Windows.Forms.TextBox();
            this.button_drawCircle = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel_drawArea
            // 
            this.panel_drawArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_drawArea.Location = new System.Drawing.Point(12, 12);
            this.panel_drawArea.Name = "panel_drawArea";
            this.panel_drawArea.Size = new System.Drawing.Size(610, 517);
            this.panel_drawArea.TabIndex = 0;
            this.panel_drawArea.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_drawArea_Paint);
            this.panel_drawArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_drawArea_MouseDown);
            // 
            // textBox_LineX0
            // 
            this.textBox_LineX0.Location = new System.Drawing.Point(698, 71);
            this.textBox_LineX0.Name = "textBox_LineX0";
            this.textBox_LineX0.Size = new System.Drawing.Size(45, 21);
            this.textBox_LineX0.TabIndex = 1;
            this.textBox_LineX0.TextChanged += new System.EventHandler(this.textBox_factor_TextChanged);
            // 
            // button_startDraw
            // 
            this.button_startDraw.Location = new System.Drawing.Point(653, 126);
            this.button_startDraw.Name = "button_startDraw";
            this.button_startDraw.Size = new System.Drawing.Size(75, 32);
            this.button_startDraw.TabIndex = 2;
            this.button_startDraw.Text = "绘制直线";
            this.button_startDraw.UseVisualStyleBackColor = true;
            this.button_startDraw.Click += new System.EventHandler(this.button_startDraw_Click);
            // 
            // textBox_LineY0
            // 
            this.textBox_LineY0.Location = new System.Drawing.Point(749, 71);
            this.textBox_LineY0.Name = "textBox_LineY0";
            this.textBox_LineY0.Size = new System.Drawing.Size(45, 21);
            this.textBox_LineY0.TabIndex = 3;
            // 
            // textBox_LineXn
            // 
            this.textBox_LineXn.Location = new System.Drawing.Point(698, 99);
            this.textBox_LineXn.Name = "textBox_LineXn";
            this.textBox_LineXn.Size = new System.Drawing.Size(45, 21);
            this.textBox_LineXn.TabIndex = 4;
            // 
            // textBox_LineYn
            // 
            this.textBox_LineYn.Location = new System.Drawing.Point(750, 98);
            this.textBox_LineYn.Name = "textBox_LineYn";
            this.textBox_LineYn.Size = new System.Drawing.Size(44, 21);
            this.textBox_LineYn.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(651, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "起点";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(651, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "终点";
            // 
            // button_chooseColor
            // 
            this.button_chooseColor.Location = new System.Drawing.Point(631, 429);
            this.button_chooseColor.Name = "button_chooseColor";
            this.button_chooseColor.Size = new System.Drawing.Size(188, 32);
            this.button_chooseColor.TabIndex = 8;
            this.button_chooseColor.Text = "选择当前画笔/油漆桶的颜色";
            this.button_chooseColor.UseVisualStyleBackColor = true;
            this.button_chooseColor.Click += new System.EventHandler(this.button_chooseColor_Click);
            // 
            // textBox_bucketX
            // 
            this.textBox_bucketX.Location = new System.Drawing.Point(698, 182);
            this.textBox_bucketX.Name = "textBox_bucketX";
            this.textBox_bucketX.Size = new System.Drawing.Size(45, 21);
            this.textBox_bucketX.TabIndex = 9;
            // 
            // textBox_bucketY
            // 
            this.textBox_bucketY.Location = new System.Drawing.Point(750, 182);
            this.textBox_bucketY.Name = "textBox_bucketY";
            this.textBox_bucketY.Size = new System.Drawing.Size(44, 21);
            this.textBox_bucketY.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(651, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "填充";
            // 
            // button_bucket4
            // 
            this.button_bucket4.Location = new System.Drawing.Point(653, 223);
            this.button_bucket4.Name = "button_bucket4";
            this.button_bucket4.Size = new System.Drawing.Size(125, 32);
            this.button_bucket4.TabIndex = 12;
            this.button_bucket4.Text = "4连通递归填充";
            this.button_bucket4.UseVisualStyleBackColor = true;
            this.button_bucket4.Click += new System.EventHandler(this.button_bucket4_Click);
            // 
            // button_bucket8
            // 
            this.button_bucket8.Location = new System.Drawing.Point(653, 261);
            this.button_bucket8.Name = "button_bucket8";
            this.button_bucket8.Size = new System.Drawing.Size(125, 32);
            this.button_bucket8.TabIndex = 13;
            this.button_bucket8.Text = "8连通递归填充";
            this.button_bucket8.UseVisualStyleBackColor = true;
            this.button_bucket8.Click += new System.EventHandler(this.button_bucket8_Click);
            // 
            // button_clearCanvas
            // 
            this.button_clearCanvas.Location = new System.Drawing.Point(307, 601);
            this.button_clearCanvas.Name = "button_clearCanvas";
            this.button_clearCanvas.Size = new System.Drawing.Size(90, 32);
            this.button_clearCanvas.TabIndex = 14;
            this.button_clearCanvas.Text = "清空图层";
            this.button_clearCanvas.UseVisualStyleBackColor = true;
            this.button_clearCanvas.Click += new System.EventHandler(this.button_clearCanvas_Click);
            // 
            // button_output
            // 
            this.button_output.Location = new System.Drawing.Point(841, 607);
            this.button_output.Name = "button_output";
            this.button_output.Size = new System.Drawing.Size(90, 32);
            this.button_output.TabIndex = 15;
            this.button_output.Text = "输出到文件";
            this.button_output.UseVisualStyleBackColor = true;
            this.button_output.Click += new System.EventHandler(this.button_output_Click);
            // 
            // button_bucketScan
            // 
            this.button_bucketScan.Location = new System.Drawing.Point(653, 299);
            this.button_bucketScan.Name = "button_bucketScan";
            this.button_bucketScan.Size = new System.Drawing.Size(125, 32);
            this.button_bucketScan.TabIndex = 16;
            this.button_bucketScan.Text = "扫描线转换填充";
            this.button_bucketScan.UseVisualStyleBackColor = true;
            this.button_bucketScan.Click += new System.EventHandler(this.button_bucketScan_Click);
            // 
            // textBox_clickY
            // 
            this.textBox_clickY.Location = new System.Drawing.Point(749, 20);
            this.textBox_clickY.Name = "textBox_clickY";
            this.textBox_clickY.Size = new System.Drawing.Size(43, 21);
            this.textBox_clickY.TabIndex = 17;
            // 
            // textBox_clickX
            // 
            this.textBox_clickX.Location = new System.Drawing.Point(700, 20);
            this.textBox_clickX.Name = "textBox_clickX";
            this.textBox_clickX.Size = new System.Drawing.Size(43, 21);
            this.textBox_clickX.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(629, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 24);
            this.label4.TabIndex = 19;
            this.label4.Text = "当前鼠标\r\n点击的坐标";
            // 
            // button_setClickStart
            // 
            this.button_setClickStart.Location = new System.Drawing.Point(810, 69);
            this.button_setClickStart.Name = "button_setClickStart";
            this.button_setClickStart.Size = new System.Drawing.Size(100, 23);
            this.button_setClickStart.TabIndex = 20;
            this.button_setClickStart.Text = "设置为当前坐标";
            this.button_setClickStart.UseVisualStyleBackColor = true;
            this.button_setClickStart.Click += new System.EventHandler(this.button_setClickStart_Click);
            // 
            // button_setClickEnd
            // 
            this.button_setClickEnd.Location = new System.Drawing.Point(810, 96);
            this.button_setClickEnd.Name = "button_setClickEnd";
            this.button_setClickEnd.Size = new System.Drawing.Size(100, 23);
            this.button_setClickEnd.TabIndex = 21;
            this.button_setClickEnd.Text = "设置为当前坐标";
            this.button_setClickEnd.UseVisualStyleBackColor = true;
            this.button_setClickEnd.Click += new System.EventHandler(this.button_setClickEnd_Click);
            // 
            // button_setClickFill
            // 
            this.button_setClickFill.Location = new System.Drawing.Point(810, 180);
            this.button_setClickFill.Name = "button_setClickFill";
            this.button_setClickFill.Size = new System.Drawing.Size(100, 23);
            this.button_setClickFill.TabIndex = 22;
            this.button_setClickFill.Text = "设置为当前坐标";
            this.button_setClickFill.UseVisualStyleBackColor = true;
            this.button_setClickFill.Click += new System.EventHandler(this.button_setClickFill_Click);
            // 
            // button_chooseImage
            // 
            this.button_chooseImage.Location = new System.Drawing.Point(631, 391);
            this.button_chooseImage.Name = "button_chooseImage";
            this.button_chooseImage.Size = new System.Drawing.Size(188, 32);
            this.button_chooseImage.TabIndex = 23;
            this.button_chooseImage.Text = "选择需要填充的图像";
            this.button_chooseImage.UseVisualStyleBackColor = true;
            this.button_chooseImage.Click += new System.EventHandler(this.button_chooseImage_Click);
            // 
            // button_imageFill
            // 
            this.button_imageFill.Location = new System.Drawing.Point(798, 261);
            this.button_imageFill.Name = "button_imageFill";
            this.button_imageFill.Size = new System.Drawing.Size(125, 32);
            this.button_imageFill.TabIndex = 24;
            this.button_imageFill.Text = "图像填充";
            this.button_imageFill.UseVisualStyleBackColor = true;
            this.button_imageFill.Click += new System.EventHandler(this.buttonImageFill_Click);
            // 
            // button_createLayer
            // 
            this.button_createLayer.Location = new System.Drawing.Point(12, 535);
            this.button_createLayer.Name = "button_createLayer";
            this.button_createLayer.Size = new System.Drawing.Size(121, 33);
            this.button_createLayer.TabIndex = 25;
            this.button_createLayer.Text = "新建透明图层";
            this.button_createLayer.UseVisualStyleBackColor = true;
            this.button_createLayer.Click += new System.EventHandler(this.button_createLayer_Click);
            // 
            // listBox_layers
            // 
            this.listBox_layers.FormattingEnabled = true;
            this.listBox_layers.ItemHeight = 12;
            this.listBox_layers.Location = new System.Drawing.Point(139, 535);
            this.listBox_layers.Name = "listBox_layers";
            this.listBox_layers.Size = new System.Drawing.Size(160, 112);
            this.listBox_layers.TabIndex = 26;
            this.listBox_layers.SelectedIndexChanged += new System.EventHandler(this.listBox_layers_SelectedIndexChanged);
            // 
            // textBox_selectedLayer
            // 
            this.textBox_selectedLayer.Location = new System.Drawing.Point(364, 535);
            this.textBox_selectedLayer.Name = "textBox_selectedLayer";
            this.textBox_selectedLayer.Size = new System.Drawing.Size(88, 21);
            this.textBox_selectedLayer.TabIndex = 27;
            // 
            // button_deleteLayer
            // 
            this.button_deleteLayer.Location = new System.Drawing.Point(12, 574);
            this.button_deleteLayer.Name = "button_deleteLayer";
            this.button_deleteLayer.Size = new System.Drawing.Size(121, 33);
            this.button_deleteLayer.TabIndex = 28;
            this.button_deleteLayer.Text = "删除图层";
            this.button_deleteLayer.UseVisualStyleBackColor = true;
            this.button_deleteLayer.Click += new System.EventHandler(this.button_deleteLayer_Click);
            // 
            // button_layerUp
            // 
            this.button_layerUp.Location = new System.Drawing.Point(12, 613);
            this.button_layerUp.Name = "button_layerUp";
            this.button_layerUp.Size = new System.Drawing.Size(58, 33);
            this.button_layerUp.TabIndex = 29;
            this.button_layerUp.Text = "上移";
            this.button_layerUp.UseVisualStyleBackColor = true;
            this.button_layerUp.Click += new System.EventHandler(this.button_layerUp_Click);
            // 
            // button_layerDown
            // 
            this.button_layerDown.Location = new System.Drawing.Point(75, 613);
            this.button_layerDown.Name = "button_layerDown";
            this.button_layerDown.Size = new System.Drawing.Size(58, 33);
            this.button_layerDown.TabIndex = 30;
            this.button_layerDown.Text = "下移";
            this.button_layerDown.UseVisualStyleBackColor = true;
            this.button_layerDown.Click += new System.EventHandler(this.button_layerDown_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(305, 538);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 31;
            this.label5.Text = "当前图层";
            // 
            // button_drawSelection
            // 
            this.button_drawSelection.Location = new System.Drawing.Point(631, 496);
            this.button_drawSelection.Name = "button_drawSelection";
            this.button_drawSelection.Size = new System.Drawing.Size(90, 33);
            this.button_drawSelection.TabIndex = 32;
            this.button_drawSelection.Text = "绘制选区";
            this.button_drawSelection.UseVisualStyleBackColor = true;
            this.button_drawSelection.Click += new System.EventHandler(this.button_drawSelection_Click);
            // 
            // button_getSelection
            // 
            this.button_getSelection.Location = new System.Drawing.Point(631, 535);
            this.button_getSelection.Name = "button_getSelection";
            this.button_getSelection.Size = new System.Drawing.Size(90, 33);
            this.button_getSelection.TabIndex = 33;
            this.button_getSelection.Text = "魔棒工具";
            this.button_getSelection.UseVisualStyleBackColor = true;
            this.button_getSelection.Click += new System.EventHandler(this.button_getSelection_Click);
            // 
            // button_showSelection
            // 
            this.button_showSelection.Location = new System.Drawing.Point(733, 535);
            this.button_showSelection.Name = "button_showSelection";
            this.button_showSelection.Size = new System.Drawing.Size(90, 33);
            this.button_showSelection.TabIndex = 34;
            this.button_showSelection.Text = "显示选区\r\n/取消显示";
            this.button_showSelection.UseVisualStyleBackColor = true;
            this.button_showSelection.Click += new System.EventHandler(this.button_showSelection_Click);
            // 
            // button_fillSelection
            // 
            this.button_fillSelection.Location = new System.Drawing.Point(798, 223);
            this.button_fillSelection.Name = "button_fillSelection";
            this.button_fillSelection.Size = new System.Drawing.Size(125, 32);
            this.button_fillSelection.TabIndex = 35;
            this.button_fillSelection.Text = "填充选区";
            this.button_fillSelection.UseVisualStyleBackColor = true;
            this.button_fillSelection.Click += new System.EventHandler(this.button_fillSelection_Click);
            // 
            // button_clearSelection
            // 
            this.button_clearSelection.Location = new System.Drawing.Point(733, 496);
            this.button_clearSelection.Name = "button_clearSelection";
            this.button_clearSelection.Size = new System.Drawing.Size(90, 33);
            this.button_clearSelection.TabIndex = 36;
            this.button_clearSelection.Text = "清除选区";
            this.button_clearSelection.UseVisualStyleBackColor = true;
            this.button_clearSelection.Click += new System.EventHandler(this.button_clearSelection_Click);
            // 
            // button_hideLayer
            // 
            this.button_hideLayer.Location = new System.Drawing.Point(307, 562);
            this.button_hideLayer.Name = "button_hideLayer";
            this.button_hideLayer.Size = new System.Drawing.Size(90, 33);
            this.button_hideLayer.TabIndex = 37;
            this.button_hideLayer.Text = "隐藏图层";
            this.button_hideLayer.UseVisualStyleBackColor = true;
            this.button_hideLayer.Click += new System.EventHandler(this.button_hideLayer_Click);
            // 
            // textBox_circleCenterX
            // 
            this.textBox_circleCenterX.Location = new System.Drawing.Point(971, 71);
            this.textBox_circleCenterX.Name = "textBox_circleCenterX";
            this.textBox_circleCenterX.Size = new System.Drawing.Size(43, 21);
            this.textBox_circleCenterX.TabIndex = 38;
            // 
            // textBox_circleCenterY
            // 
            this.textBox_circleCenterY.Location = new System.Drawing.Point(1028, 71);
            this.textBox_circleCenterY.Name = "textBox_circleCenterY";
            this.textBox_circleCenterY.Size = new System.Drawing.Size(43, 21);
            this.textBox_circleCenterY.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(997, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 40;
            this.label6.Text = "圆心坐标";
            // 
            // button_setClickCenter
            // 
            this.button_setClickCenter.Location = new System.Drawing.Point(971, 96);
            this.button_setClickCenter.Name = "button_setClickCenter";
            this.button_setClickCenter.Size = new System.Drawing.Size(100, 23);
            this.button_setClickCenter.TabIndex = 42;
            this.button_setClickCenter.Text = "设置为当前坐标";
            this.button_setClickCenter.UseVisualStyleBackColor = true;
            this.button_setClickCenter.Click += new System.EventHandler(this.button_setClickCenter_Click);
            // 
            // textBox_circleRadius
            // 
            this.textBox_circleRadius.Location = new System.Drawing.Point(1006, 126);
            this.textBox_circleRadius.Name = "textBox_circleRadius";
            this.textBox_circleRadius.Size = new System.Drawing.Size(65, 21);
            this.textBox_circleRadius.TabIndex = 43;
            // 
            // button_drawCircle
            // 
            this.button_drawCircle.Location = new System.Drawing.Point(986, 153);
            this.button_drawCircle.Name = "button_drawCircle";
            this.button_drawCircle.Size = new System.Drawing.Size(75, 32);
            this.button_drawCircle.TabIndex = 45;
            this.button_drawCircle.Text = "画圆";
            this.button_drawCircle.UseVisualStyleBackColor = true;
            this.button_drawCircle.Click += new System.EventHandler(this.button_drawCircle_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(971, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 46;
            this.label7.Text = "半径";
            // 
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 651);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button_drawCircle);
            this.Controls.Add(this.textBox_circleRadius);
            this.Controls.Add(this.button_setClickCenter);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_circleCenterY);
            this.Controls.Add(this.textBox_circleCenterX);
            this.Controls.Add(this.button_hideLayer);
            this.Controls.Add(this.button_clearSelection);
            this.Controls.Add(this.button_fillSelection);
            this.Controls.Add(this.button_showSelection);
            this.Controls.Add(this.button_getSelection);
            this.Controls.Add(this.button_drawSelection);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_layerDown);
            this.Controls.Add(this.button_layerUp);
            this.Controls.Add(this.button_deleteLayer);
            this.Controls.Add(this.textBox_selectedLayer);
            this.Controls.Add(this.listBox_layers);
            this.Controls.Add(this.button_createLayer);
            this.Controls.Add(this.button_imageFill);
            this.Controls.Add(this.button_chooseImage);
            this.Controls.Add(this.button_setClickFill);
            this.Controls.Add(this.button_setClickEnd);
            this.Controls.Add(this.button_setClickStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_clickX);
            this.Controls.Add(this.textBox_clickY);
            this.Controls.Add(this.button_bucketScan);
            this.Controls.Add(this.button_output);
            this.Controls.Add(this.button_clearCanvas);
            this.Controls.Add(this.button_bucket8);
            this.Controls.Add(this.button_bucket4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_bucketY);
            this.Controls.Add(this.textBox_bucketX);
            this.Controls.Add(this.button_chooseColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_LineYn);
            this.Controls.Add(this.textBox_LineXn);
            this.Controls.Add(this.textBox_LineY0);
            this.Controls.Add(this.button_startDraw);
            this.Controls.Add(this.textBox_LineX0);
            this.Controls.Add(this.panel_drawArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "mainFrm";
            this.Text = "图形学";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_drawArea;
        private System.Windows.Forms.TextBox textBox_LineX0;
        private System.Windows.Forms.Button button_startDraw;
        private System.Windows.Forms.TextBox textBox_LineY0;
        private System.Windows.Forms.TextBox textBox_LineXn;
        private System.Windows.Forms.TextBox textBox_LineYn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_chooseColor;
        private System.Windows.Forms.TextBox textBox_bucketX;
        private System.Windows.Forms.TextBox textBox_bucketY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_bucket4;
        private System.Windows.Forms.Button button_bucket8;
        private System.Windows.Forms.Button button_clearCanvas;
        private System.Windows.Forms.Button button_output;
        private System.Windows.Forms.Button button_bucketScan;
        private System.Windows.Forms.TextBox textBox_clickY;
        private System.Windows.Forms.TextBox textBox_clickX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_setClickStart;
        private System.Windows.Forms.Button button_setClickEnd;
        private System.Windows.Forms.Button button_setClickFill;
        private System.Windows.Forms.Button button_chooseImage;
        private System.Windows.Forms.Button button_imageFill;
        private System.Windows.Forms.Button button_createLayer;
        private System.Windows.Forms.ListBox listBox_layers;
        private System.Windows.Forms.TextBox textBox_selectedLayer;
        private System.Windows.Forms.Button button_deleteLayer;
        private System.Windows.Forms.Button button_layerUp;
        private System.Windows.Forms.Button button_layerDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_drawSelection;
        private System.Windows.Forms.Button button_getSelection;
        private System.Windows.Forms.Button button_showSelection;
        private System.Windows.Forms.Button button_fillSelection;
        private System.Windows.Forms.Button button_clearSelection;
        private System.Windows.Forms.Button button_hideLayer;
        private System.Windows.Forms.TextBox textBox_circleCenterX;
        private System.Windows.Forms.TextBox textBox_circleCenterY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_setClickCenter;
        private System.Windows.Forms.TextBox textBox_circleRadius;
        private System.Windows.Forms.Button button_drawCircle;
        private System.Windows.Forms.Label label7;
    }
}

