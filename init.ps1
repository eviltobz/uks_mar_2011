"Copying configuration files"
cp build\local_properties.rb.customize build\local_properties.rb
cp build\connection_details.rb.customize build\connection_details.rb

"Creating the remote link to developwithpassion code base"
git remote rm jp
git remote add jp git://github.com/developwithpassion/uks_feb_2011.git
