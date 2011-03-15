class TemplateFiles
  def initialize(local_settings,database_details)
    @files = Dir.glob("**/*.erb").map{|file_name| TemplateFile.new(file_name,local_settings,database_details)}
  end

  def expand
    @files.each{|file|file.expand}
  end
end

class TemplateFile
  def initialize(filename,local_settings,database_details)
    @database_details = database_details
    @file = filename
    @local_settings = local_settings
  end

  def expand
    database_details = @database_details
    local_settings = @local_settings

    file_name = File.basename(@file).name_without_template_extension
    file_name = ".#{file_name}" if (/\.dotfile/ =~ @file)
    output = File.join(File.dirname(@file),file_name)
    File.delete(output) if File.exists?(output)
    File.open(output,'w') {|converted| converted << ERB.new(File.read(@file)).result(binding)}
  end
end
