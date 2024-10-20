import { Component, OnInit } from '@angular/core';
import { BookService } from '../book.service';
import { Observable } from 'rxjs';
import { Book } from '../book';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-books',
  standalone: true,
  imports: [AsyncPipe],
  templateUrl: './books.component.html',
  styleUrl: './books.component.css'
})
export class BooksComponent implements OnInit {
  books!: Observable<Book[]>;
  
  constructor(private bookService: BookService) {
  }

  ngOnInit(): void {
    this.books = this.bookService.getBooks();
  }

}
