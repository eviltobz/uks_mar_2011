namespace :specs do
  desc 'view the spec report'
  task :view do
    puts Project.report_folder
    system "start #{Project.report_folder}/#{Project.name}.specs.html"
  end

  desc 'run the specs for the project'
  task :run  => [:init,:compile] do
    Dir.glob(File.join('thirdparty','developwithpassion.specifications','*')).each do|file|
      FileUtils.cp(file,'artifacts')
    end
    sh "artifacts/mspec-clr4.exe", "--html", "#{Project.report_folder}/#{Project.name}.specs.html", "-x", "example", *([] + Project.spec_assemblies)
  end
end
