#apt-get install libasound2-dev
#apt-get install libxml++2.6-dev
#


#Which compiler to use
CC=g++

#Flag says to check the include path within . (this file) before the default include path (/usr/include).
#The pkg-config automates the dynamic links to the xml parsing lib.
CWARN = -Werror -Wreturn-type -Wformat -Wparentheses -Wswitch -Wunused-function -Wunused-label -Wunused-parameter -Wunused-variable -Wunused-value -Wsign-compare -Wuninitialized
CFLAGS=-I. -lasound `pkg-config libxml++-2.6 --cflags --libs` -g $(CWARN)

#required headers
DEPS = event.h power.h event_list.h file_reader.h AudioLib/audiolib.h AudioLib/aconfig.h error_output.h

#Files to compile. although the files are <name>.cpp, you actualy would give the files <name>.o
AUDIO_OBJ = audiolib.o
OBJ = Event.o Power.o Event_List.o File_Reader.o Logger.o main.o Error_Output.o $(AUDIO_OBJ)

#In makefiles, the first declaration runs. In this case, 'all'runs everything but clean.
all: $(OBJ) hoot

%.o: %.cpp $(DEPS)
	$(CC) -c -o $@ $< $(CFLAGS)


hoot: $(OBJ)
	$(CC) -o $@ $^ $(CFLAGS) 

#type 'make clean' to remove all .o files.
clean:
	\rm -f *.o *~
