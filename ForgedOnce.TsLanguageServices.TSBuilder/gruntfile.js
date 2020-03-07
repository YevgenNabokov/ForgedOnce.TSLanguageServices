module.exports = function (grunt) {
    /// Project configuration.
    grunt.initConfig({
        destinationFolder: '../GeneratorAppOutput',
        clean: {
            options: {
                'force': true
            },
            main: ['<%= destinationFolder %>/*']
        },
        copy: {
            main: {
                files: [
                    // includes files within path
                    {
                        expand: true, src: [
                            'generationLauncher.js',
                            'generationManager.js',
                            'IntermadiateModel.js',
                            'tsCodeGenerator.js'], dest: '<%= destinationFolder %>/'
                    },

                    {
                        expand: true, src: [
                            'node_modules/typescript/**'], dest: '<%= destinationFolder %>/'
                    },

                    // includes files within path and its sub-directories
                    //{ expand: true, src: ['path/**'], dest: 'dest/' },

                    // makes all src relative to cwd
                    //{ expand: true, cwd: 'path/', src: ['**'], dest: 'dest/' },

                    // flattens results to a single level
                    //{ expand: true, flatten: true, src: ['path/**'], dest: 'dest/', filter: 'isFile' },
                ],
            },
        }
    });

    grunt.loadNpmTasks('grunt-contrib-clean');

    grunt.loadNpmTasks('grunt-contrib-copy');

    grunt.registerTask('default', ['clean', 'copy']);
};