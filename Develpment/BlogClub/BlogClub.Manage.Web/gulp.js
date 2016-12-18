var gulp = require('gulp');
var del = require('del');

var paths = {
    angularPatch: [
        "node_modules/core-js*/**/*",
        "node_modules/zone.js*/**/*",
        "node_modules/reflect-metadata*/*.js",
         "node_modules/reflect-metadata*/*.map",
        "node_modules/systemjs*/dist*/*.js",
         "node_modules/systemjs*/dist*/*.map"
    ],
    angularSrc: [
        "node_modules/@angular/core/bundles/core.umd.js",
        "node_modules/@angular/common/bundles/common.umd.js",
        "node_modules/@angular/compiler/bundles/compiler.umd.js",
        "node_modules/@angular/platform-browser/bundles/platform-browser.umd.js",
        "node_modules/@angular/platform-browser-dynamic/bundles/platform-browser-dynamic.umd.js",
        "node_modules/@angular/http/bundles/http.umd.js",
        "node_modules/@angular/router/bundles/router.umd.js",
        "node_modules/@angular/forms/bundles/forms.umd.js",
        "node_modules/@angular/upgrade/bundles/upgrade.umd.js"
        //"node_modules/",
    ],
    rxjsSrc: "node_modules/rxjs/**/*",
    TSSrc: "Scripts/**/*.js",
    TSTarget: "wwwroot/js",
    Tartget: "wwwroot/lib"
}
//手工构建一次
gulp.task("copyangularfiles", function () {
    //gulp.src(paths.angularSrc).pipe(gulp.dest(paths.Tartget));

    paths.angularSrc.forEach(function (path) {
        var tpath = path.replace("node_modules", paths.Tartget).split('/');
        gulp.src(path).pipe(gulp.dest(tpath.slice(0, tpath.length - 1).join('/')));
    });
    gulp.src(paths.rxjsSrc).pipe(gulp.dest(paths.Tartget + "/rxjs"));
    gulp.src(paths.angularPatch).pipe(gulp.dest(paths.Tartget + "/patch"));

});
//加入任务->绑定->生成前
gulp.task("copytsfiles", function () {
    gulp.src(paths.TSSrc).pipe(gulp.dest(paths.TSTarget));
})

gulp.task('default', ['copytsfiles'], function () {
    // place code for your default task here
});