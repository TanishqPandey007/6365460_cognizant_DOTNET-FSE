using System;

public abstract class Document
{
    public abstract
    void Print();
}
public class WordDocument : Document{
    public override void Print(){
        Console.WriteLine("Printing Word Document");
    }
}

public class PdfDocument : Document{
    public override void Print(){
        Console.WriteLine("Printing Pdf Document");
    }
}

public class ExcelDocument : Document{
    public override void Print(){
        Console.WriteLine("Printing Excel Document");
    }
}

public abstract class DocumentFactory{
    public abstract Document CreateDocument();
}

public class WordDocumentFactory : DocumentFactory{
    public override Document CreateDocument(){
        return new WordDocument();
    }
}

public class PdfDocumentFactory : DocumentFactory{
    public override Document CreateDocument(){
        return new PdfDocument();
    }
}

public class ExcelDocumentFactory : DocumentFactory{
    public override Document CreateDocument(){
        return new ExcelDocument();
    }
}

class Program{
    static void Main(){
        DocumentFactory wordFactory = new WordDocumentFactory();
        Document wordDoc = wordFactory.CreateDocument();
        wordDoc.Print();
        DocumentFactory pdfFactory = new PdfDocumentFactory();
        Document pdfDoc = pdfFactory.CreateDocument();
        pdfDoc.Print();
         DocumentFactory excelFactory = new ExcelDocumentFactory();
        Document excelDoc = excelFactory.CreateDocument();
        excelDoc.Print();
    }
}