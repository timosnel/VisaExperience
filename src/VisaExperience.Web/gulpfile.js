/// <binding Clean='clean' />
'use strict';

var gulp = require('gulp'),
    rimraf = require('rimraf'),
    concat = require('gulp-concat'),
    cssmin = require('gulp-cssmin'),
    uglify = require('gulp-uglify'),
    jshint = require('gulp-jshint'),
    sass = require('gulp-sass'),
    sasslint = require('gulp-sass-lint');

var webroot = './wwwroot/';
var gulpfile = './gulpfile.js';

var paths = {
    js: webroot + 'js/**/*.js',
    minJs: webroot + 'js/**/*.min.js',
    sass: webroot + 'css/**/*.scss',
    css: webroot + 'css/**/*.css',
    minCss: webroot + 'css/**/*.min.css',
    concatJsDest: webroot + 'js/site.min.js',
    concatCssDest: webroot + 'css/site.min.css'
};

gulp.task('clean:js', function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task('clean:css', function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task('clean', ['clean:js', 'clean:css']);

gulp.task('lint:js', function() {
    return gulp.src([gulpfile, paths.js])
        .pipe(jshint())
        .pipe(jshint.reporter('jshint-stylish'))
        .pipe(jshint.reporter('fail'));
});

gulp.task('lint:css', function() {
    gulp.src(paths.sass)
        .pipe(sasslint())
        .pipe(sasslint.format())
        .pipe(sasslint.failOnError());
});

gulp.task('lint', ['lint:js', 'lint:css']);

gulp.task('sass', function() {
    return gulp.src(paths.sass)
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest(paths.css));
});

gulp.task('min:js', function () {
    return gulp.src([paths.js, '!' + paths.minJs], { base: '.' })
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest('.'));
});

gulp.task('min:css', function () {
    return gulp.src([paths.css, '!' + paths.minCss])
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest('.'));
});

gulp.task('min', ['min:js', 'min:css']);
