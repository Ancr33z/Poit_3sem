#include"stdafx.h"

#include"Error.h"
#include"Parm.h"
#include"Log.h"
#include"In.h"

int _tmain(int argc, _TCHAR* argv[]) {

	setlocale(LC_ALL, "rus");

	std::cout << "---- ���� Parm::getparm ---" << std::endl << std::endl;
	try {
		Parm::PARM parm = Parm::getparm(argc, argv);

		wcout << "-in: " << parm.in<<", -out: " << parm.out << ", -log: " << parm.log << endl<<endl;
	}
	catch (Error::ERROR e) {
		cout << "������ " << e.id << ":" << e.message << endl<<endl;
	};

	std::cout << "---- ���� In::getin ---" << std::endl << std::endl;
	try { 
		Parm::PARM parm = Parm::getparm(argc, argv);
		In::IN in = In::getin(parm.in);
		cout << in.text << endl;
		cout <<"����� ��������: " << in.size << endl;
		cout << "����� �����: " << in.lines << endl;
		cout << "���������: " << in.ignore << endl;
	}
	catch (Error::ERROR e) {
		cout << "������ " << e.id << ":" << e.message << endl;
	}

	Log::LOG log;
	try
	{
		Parm::PARM parm = Parm::getparm(argc, argv);
		log = Log::getlog(parm.log, parm.out);
		Log::WriteLine(log, (char*)"����:", (char*)" ��� ������\n", "");
		Log::WriteLine(log, (char*)"����:", (char*)" ��� ������\n", "");
		Log::WriteLog(log);
		Log::WriteParm(log, parm);
		In::IN in = In::getin(parm.in);
		Log::WriteOut(log, in);
		Log::WriteIn(log, in);
		Log::Close(log);
	}
	catch (Error::ERROR e)
	{
		Log::WriteError(log, e);
	};

	system("pause");
	return 0;


}