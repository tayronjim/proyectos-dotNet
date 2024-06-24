function list_child_processes () {
    local ppid=$1;
    local current_children=$(pgrep -P $ppid);
    local local_child;
    if [ $? -eq 0 ];
    then
        for current_child in $current_children
        do
          local_child=$current_child;
          list_child_processes $local_child;
          echo $local_child;
        done;
    else
      return 0;
    fi;
}

ps 38802;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 38802 > /dev/null;
done;

for child in $(list_child_processes 38893);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/tayronijimenez/CS/proyectoReact1/bin/Debug/net6.0/7a2c2d7635944364828dba896418a838.sh;
