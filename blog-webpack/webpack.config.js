const path = require('path')  //路径操作  node.js 语法

const htmlWebpackPlugin=require('html-webpack-plugin')

module.exports={
    mode: 'development', //必须  因为手动是 webpack 入口路径 --output 输入路径 --mode development
    entry: path.join(__dirname,'./src/main.js'), //入口
    output: {  //出口
        path: path.join(__dirname,'./dist'), //指定输出文件放在那里
        filename: 'bundle.js'  //指定输出文件名称
    },
    plugins: [   //插件都放在plugins中
        new htmlWebpackPlugin({  //创建一个再内存中生成html页面的插件
            template: path.join(__dirname,'./src/index.html'),//根据指定的模板页面在内存中生成页面
            filename: 'index.html'  //指定内存中生成的页面名称

        })
    ],
    module: {  //这个节点，用于配置第三方模块加载器
        rules: [ //所有第三方加载模块的匹配规则  正则表达匹配
            { test: /\.css$/,use: ['style-loader','css-loader'] },//找到.css文件然后用第三方模块加载器
        ]
    }
}