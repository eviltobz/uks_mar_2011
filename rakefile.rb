require 'rake'
require 'rake/clean'
require 'fileutils'
require 'erb'

['build/tools/Rake','build',File.join(%w[build rake_tasks])].each do|pattern|
  Dir.glob(File.join(File.dirname(__FILE__),pattern,"*.rb")).each do|item|
    require item
  end
end

#load settings that differ by machine
@database_details = DbDetails.new
@local_settings = LocalSettings.new
@template_files = TemplateFiles.new(@local_settings,@database_details)

COMPILE_TARGET = 'debug'

CLEAN.include(File.join('artifacts',"*.*"),'**/*.sql')

def create_sql_fileset(folder)
  FileList.new(File.join('product','sql',folder,'**/*.sql'))
end

template_code_dir = File.join('product','templated_code')

#configuration files
config_files = FileList.new(File.join('product','config','*.erb')).select{|fn| ! fn.include?('app.config')}

app_config = File.join('product','config','app.config.erb')

sql_runner = SqlRunner.new(@database_details)
#
#target folders that can be run from VS
solution_file = "solution.sln"

task :default => ["specs:run"]

task :init  => :clean do
  ['artifacts',Project.specs_dir,Project.report_folder].each{|folder| mkdir folder if ! File.exists?(folder)}
end

task :expand_all_template_files do
  @template_files.expand
end


desc 'compiles the project'
task :compile => :init do
  MSBuildRunner.compile :compile_target => COMPILE_TARGET, :solution_file => solution_file
end

task :from_ide => :expand_all_template_files do
  Project.spec_assemblies.each do |assembly|
      FileUtils.cp(app_config.name_without_template_extension,
      File.join('artifacts',"#{File.basename(assembly)}.config"))
  end

  FileUtils.cp(app_config.name_without_template_extension,File.join(
  Project.startup_dir,Project.startup_config))

  config_files.each do |file|
      ['artifacts',Project.startup_dir].each do|folder|
        FileUtils.cp(file.name_without_template_extension,
        File.join(folder,File.basename(file.name_without_template_extension)))
      end
  end
end


desc "open the solution"
task :sln do
path = "devenv #{solution_file}"
  Thread.new do
    system path
  end
end
